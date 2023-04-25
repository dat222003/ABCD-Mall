using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Runtime.Remoting.Metadata.W3cXsd2001;
using System.Web;
using System.Web.Mvc;
using ABCD_Mall.Models;

namespace ABCD_Mall.Controllers
{
    public class RoomSeatsController : Controller
    {
        private Entities db = new Entities();

        // GET: RoomSeats
        public ActionResult Index()
        {
            var roomSeats = db.RoomSeats.Include(r => r.Room).Include(r => r.Seat);
            return View(roomSeats.ToList());
        }

        // GET: RoomSeats/Details/5
        public ActionResult Details(int? roomId, int? seatId)
        {
            if (roomId == null || seatId == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            RoomSeat roomSeat = db.RoomSeats.SingleOrDefault(rs => rs.roomId == roomId && rs.seatId == seatId);
            if (roomSeat == null)
            {
                return HttpNotFound();
            }
            ViewBag.roomId = new SelectList(db.Rooms, "roomId", "roomId", roomSeat.roomId);
            ViewBag.seatId = new SelectList(db.Seats, "seatId", "seatName", roomSeat.seatId);
            return View(roomSeat);
        }

        // GET: RoomSeats/Edit/5
        public ActionResult Edit(int? roomId, int? seatId)
        {
            if (roomId == null || seatId == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            RoomSeat roomSeat = db.RoomSeats.SingleOrDefault(rs => rs.roomId == roomId && rs.seatId == seatId);
            if (roomSeat == null)
            {
                return HttpNotFound();
            }
            ViewBag.roomId = new SelectList(db.Rooms, "roomId", "roomId", roomSeat.roomId);
            ViewBag.seatId = new SelectList(db.Seats, "seatId", "seatName", roomSeat.seatId);
            return View(roomSeat);
        }

        // POST: RoomSeats/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "roomId,seatId,isAvailable")] RoomSeat roomSeat)
        {
            if (ModelState.IsValid)
            {
                db.Entry(roomSeat).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.roomId = new SelectList(db.Rooms, "roomId", "roomId", roomSeat.roomId);
            ViewBag.seatId = new SelectList(db.Seats, "seatId", "seatName", roomSeat.seatId);
            return View(roomSeat);
        }

        // GET: RoomSeats/Delete/5
        public ActionResult Delete(int? roomId, int? seatId)
        {
            if (roomId == null || seatId == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            RoomSeat roomSeat = db.RoomSeats.SingleOrDefault(rs => rs.roomId == roomId && rs.seatId == seatId);
            if (roomSeat == null)
            {
                return HttpNotFound();
            }
            return View(roomSeat);
        }

        // POST: RoomSeats/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int roomId, int seatId)
        {
            RoomSeat roomSeat = db.RoomSeats.SingleOrDefault(rs => rs.roomId == roomId && rs.seatId == seatId);
            db.RoomSeats.Remove(roomSeat);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
