using SportDash.Models;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;

namespace SportDash.Repository
{
    public interface IPlaygroundReservationRepository
    {
        public bool Add(PlaygroundReservation playgroundReservation);
        //Get all reservations for one user
        //userId: UerId, playgroundId: PlaygroundId
        public List<PlaygroundReservation> GetUserReservations(string userId,string playgroundId);
        //Get All Reservations for this playground
        //id: PlaygroundId
        public List<PlaygroundReservation> GetAll(string id);
        //Get all requests to accpet it or refuse
        //id: PlaygroundId
        public List<PlaygroundReservation> GetRequests(string id);
        public PlaygroundReservation GetPlaygroundReservationById(int id);
        //Admin accept the reservation request
        //id: Id
        public bool AcceptReservation(int id);
        //Admin refuse the reservation request
        //id: Id
        public bool RefuseReservation(int id);
        //get the username who reserve the playground
        //id: UserId
        public string GetUsername(string id);
        //Check if the reservation in correct time or not
        public bool IsValid(PlaygroundReservation reservation);
        public bool Delete(int id);
        //Get all reservation of this month 
        //id: PlaygroundId
        public List<PlaygroundReservation> GetReservationsByMonth(string id,int month);
        //Get all reservation of this day
        //id: PlaygroundId
        public List<PlaygroundReservation> GetReservationsByDay(string id,int day,int month,int year);
        //Get all reservation of this week
        //id: PlaygroundId
        public List<PlaygroundReservation> GetReservationsByWeek(string id, int fromDay,int toDay);
    }
}
