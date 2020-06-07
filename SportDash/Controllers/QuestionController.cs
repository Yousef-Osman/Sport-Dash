﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using SportDash.Components.Question;
using SportDash.Data;
using SportDash.Models;
using SportDash.Repository;
using SportDash.ViewModels;

namespace SportDash.Controllers
{
    public class QuestionController : Controller
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly IAuthorizationService _authorizationService;
        private readonly IUserRepository _userRepository;
        private readonly IImageRepository _imageRepository;
        private readonly IQuestionRepository _questionRepository;
        private readonly ICommentRepository _commentRepository;

        public QuestionController(UserManager<ApplicationUser> userManager,
                                    SignInManager<ApplicationUser> signInManager,
                                    IAuthorizationService authorizationService,
                                    IUserRepository userRepository,
                                    IImageRepository imageRepository,
                                    IQuestionRepository questionRepository,
                                    ICommentRepository commentRepository)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _authorizationService = authorizationService;
            _userRepository = userRepository;
            _imageRepository = imageRepository;
            _questionRepository = questionRepository;
            _commentRepository = commentRepository;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id">it is the Question Id</param>
        /// <returns></returns>
        public async Task<IActionResult> Index()
        {
            var dataModel = new DataViewModel();
            var user = await _userManager.GetUserAsync(User);
            //Console.WriteLine(User.IsInRole(""));
            dataModel.ControllerName = "Question";
            dataModel.isCurrentUser = false;

            if (_signInManager.IsSignedIn(User))
            {
                dataModel.CurrentUser = user;
                dataModel.isCurrentUser = true;
            }
            else
            {
                return RedirectToAction("Index", "Home");
            }
            return View(dataModel);
        }

        /// <summary>
        /// Action for previewing the question alongside the with its Comments
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Returns the IActionResult if the provided id is valid and exists, otherwise it redirects to the home page</returns>
        public async Task<IActionResult> Question(string id)
        {
            var dataModel = new DataViewModel();
            var user = await _userManager.GetUserAsync(User);
            if (_signInManager.IsSignedIn(User))
            {
                if (id != null)
                {
                    //get the Question and check if Question.UserId = user.id check id 
                    int Id;
                    if (int.TryParse(id, out Id))
                    {
                        Question question = _questionRepository.GetQuestion(Id);
                        if (question != null)
                        {
                            //question exists with provided id
                            dataModel.ControllerName = "Question";
                            dataModel.CurrentUser = user;
                            if (question.UserId == user.Id)
                            {
                                //for editing question if it is his/her.
                                dataModel.isCurrentUser = true;
                            }
                            else
                            {
                                dataModel.isCurrentUser = false;
                            }

                            List<Comment> comments = _commentRepository.GetAllCommentsForQuestion(Id);
                            List<UserCommentViewModel> userCommentViewModel = new List<UserCommentViewModel>();
                            foreach (var comment in comments)
                            {
                                userCommentViewModel.Add(new UserCommentViewModel() { Comment = comment, User = _userRepository.GetApplicationUser(comment.UserId) });
                            }
                            QuestionAndCommentsViewModel questionAndCommentsViewModel = new QuestionAndCommentsViewModel();
                            questionAndCommentsViewModel.DataViewModel = dataModel;
                            questionAndCommentsViewModel.Question = question;
                            questionAndCommentsViewModel.Question.User = _userRepository.GetApplicationUser(question.UserId);
                            questionAndCommentsViewModel.UserComment = userCommentViewModel;
                            return View(questionAndCommentsViewModel);
                        }
                        else
                        {
                            //logged but entered unexisting id
                            return RedirectToAction("Index", "Home");
                        }
                    }
                    else
                    {
                        //logged but enter unvalid id
                        return RedirectToAction("Index", "Home");
                    }
                }
                else
                {
                    //logged but didn't enter id
                    return RedirectToAction("Index", "Home");
                }
            }
            else
            {
                //not logged in
                return RedirectToAction("Index", "Home");
            }
        }

        public async Task<IActionResult> MyQuestions()
        {
            var dataModel = new DataViewModel();
            var user = await _userManager.GetUserAsync(User);
            if (_signInManager.IsSignedIn(User))
            {
                List<Question> questions = _questionRepository.GetQuestionByUser(user.Id);
                //question exists with provided id
                dataModel.ControllerName = "Question";
                dataModel.CurrentUser = user;
                dataModel.isCurrentUser = true;
                MyQuestionsViewModel myQuestionsViewModel = new MyQuestionsViewModel()
                {
                    DataViewModel = dataModel,
                    Questions = questions
                };
                return View(myQuestionsViewModel);
            }
            else
            {
                //logged but didn't enter id
                return RedirectToAction("Index", "Home");
            }
        }

        
        public async Task<IActionResult> Category()
        {
            var dataModel = new DataViewModel();
            var user = await _userManager.GetUserAsync(User);
            if (_signInManager.IsSignedIn(User))
            {
                List<Question> questions = _questionRepository.GetQuestionByCategory(QuestionAbout.Club);
                dataModel.ControllerName = "Question";
                CategoryQuestionsViewModel categoryQuestionsViewModel = new CategoryQuestionsViewModel()
                {
                    DataViewModel = dataModel,
                    Questions = questions
                };
                return View(categoryQuestionsViewModel);
            }
            return RedirectToAction("Index", "Home");
        }

        [HttpGet]
        public IActionResult GetByCategory(int CategoryId)
        {
            List<Question> questions = _questionRepository.GetQuestionByCategory((QuestionAbout)CategoryId);
            
            foreach (var question in questions)
            {
                question.User = _userRepository.GetApplicationUser(question.UserId);
            }
            //status code 200
            return Ok(new JsonResult(questions));
        }
        [HttpPost]
        public IActionResult Ask(Question question)
        {
            question = _questionRepository.Ask(question);
            if (question != null)
            {
                return new JsonResult(question);
            }
            else
            {
                return new BadRequestResult();
            }
        }

        [HttpPost]
        public IActionResult Comment(Comment comment)
        {
            comment = _commentRepository.AddComment(comment);
            if (comment != null)
            {
                return new JsonResult(comment);
            }
            else
            {
                return new BadRequestResult();
            }
        }


        [HttpPost]
        public IActionResult EditQuestion(Question question)
        {
            bool IsUpdated = _questionRepository.Update(question);
            if (IsUpdated)
            {
                return Ok();
            }
            else
            {
                return BadRequest();
            }
        }

    }
}