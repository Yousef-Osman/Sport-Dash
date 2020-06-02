using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.EntityFrameworkCore;
using SportDash.Data;
using SportDash.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace SportDash.Repository
{
    public class PlaygroundReservationRepository : IPlaygroundReservationRepository
    {
        private readonly ApplicationDbContext _DbContext;

        public PlaygroundReservationRepository(ApplicationDbContext DbContext)
        {
            _DbContext = DbContext;
        }

        public bool Add(PlaygroundReservation playgroundReservation)
        {
            if (playgroundReservation != null && IsValid(playgroundReservation))
            {
                _DbContext.playgroundReservations.Add(playgroundReservation);
                _DbContext.SaveChanges();
                return true;
            }
            else
            {
                return false;
            }
        }

        public List<PlaygroundReservation> GetUserReservations(string userId,string playgroundId)
        {
            return _DbContext.playgroundReservations.Where(r=>r.UserId == userId && r.PlaygroundId == playgroundId).OrderBy(r=>r.StartTime).OrderBy(r => r.Date).ToList();
        }

        public List<PlaygroundReservation> GetAll(string id)
        {
            return _DbContext.playgroundReservations.Where(r=>r.PlaygroundId==id && r.Status=="Accepted").OrderBy(r => r.StartTime).OrderBy(r => r.Date).ToList();
        }

        public  List<PlaygroundReservation> GetRequests(string id)
        {
            return _DbContext.playgroundReservations.Where(r=>r.PlaygroundId==id && r.Status=="Waiting").OrderBy(r => r.StartTime).OrderBy(r => r.Date).ToList();
        }

        public bool AcceptReservation(int id)
        {
            var reservation = _DbContext.playgroundReservations.Find(id);
            if (IsValid(reservation))
            {
                reservation.Status = "Accepted";
                _DbContext.Entry<PlaygroundReservation>(reservation).State = EntityState.Modified;
                _DbContext.SaveChanges();
                return true;
            }
            else
                return false;
        }

        public bool RefuseReservation(int id)
        {
            return Delete(id);
        }

        public string GetUsername(string id)
        {
            return _DbContext.Users.Where(r => r.Id == id).Select(r => r.FullName).FirstOrDefault();
        }

        public bool Delete(int id)
        {
            PlaygroundReservation playgroundReservation = _DbContext.playgroundReservations.Find(id);
            if (playgroundReservation != null)
            {
                _DbContext.playgroundReservations.Remove(playgroundReservation);
                _DbContext.SaveChanges();
                return true;
            }
            return false;
        }

        public List<PlaygroundReservation> GetReservationsByMonth(string id, int month)
        {
            return _DbContext.playgroundReservations.Where(r => r.PlaygroundId == id && r.Date.Month== month && r.Status == "Accepted").OrderBy(r => r.Date).OrderBy(r => r.StartTime).ToList();
        }

        public List<PlaygroundReservation> GetReservationsByDay(string id, int day,int month,int year)
        {
            return _DbContext.playgroundReservations.Include(r=>r.User).Where(r => r.PlaygroundId == id && r.Date.Day == day && r.Date.Month==month && r.Date.Year == year && r.Status == "Accepted").OrderBy(r=>r.StartTime).ToList();
        }

        public List<PlaygroundReservation> GetReservationsByWeek(string id, int fromDay, int toDay)
        {
            return _DbContext.playgroundReservations.Where(r => r.PlaygroundId == id && r.Date.Day >= fromDay && r.Date.Day <= toDay && r.Status=="Accepted").OrderBy(r => r.Date).OrderBy(r => r.StartTime).ToList();
        }

        public bool IsValid(PlaygroundReservation reservation)
        {
            var allReservations = GetReservationsByDay(reservation.PlaygroundId, reservation.Date.Day, reservation.Date.Month,reservation.Date.Year);
            bool flag = true;
            foreach(var r in allReservations)
            {
                if ((reservation.StartTime >= r.StartTime && reservation.StartTime < r.EndTime)||
                    (reservation.EndTime > r.StartTime && reservation.EndTime <= r.EndTime))
                {
                    flag = false;
                    break;
                }
            }
            return flag;
        }
    }
}
