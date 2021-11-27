using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace MVCAngularHotelBooking.Controllers
{
    public class HotelAPIController : ApiController
    {
        HotelDBEntities1 objapi = new HotelDBEntities1();

        // Para selecionar os detalhes do hotel
        [HttpGet]
        public IEnumerable<USP_HotelMaster_Select_Result> getHotelRooms(string RoomNo)
        {
            if (RoomNo == null)
                RoomNo = "";
            return objapi.USP_HotelMaster_Select(RoomNo).AsEnumerable();
        }

        //Para inserir detalhes de quartos de hotel
        [HttpGet]
        public IEnumerable<string> insertHotelRoom(string RoomNo, string RoomType, string Prize)
        {
            if (RoomNo == null)
                RoomNo = "";

            if (RoomType == null)
                RoomType = "";

            if (Prize == null)
                Prize = "";

            return objapi.USP_Hotel_Insert(RoomNo, RoomType, Prize).AsEnumerable();

        }


        // para pesquisar todos os detalhes de reserva de quarto
        [HttpGet]
        public IEnumerable<USP_RoomBooking_SelectALL_Result> getRoomBookingDetails(string RoomID)
        {
            if (RoomID == null)
                RoomID = "";

            return objapi.USP_RoomBooking_SelectALL(RoomID).AsEnumerable();
        }


        // para pesquisar todos os detalhes do painel da sala
        [HttpGet]
        public IEnumerable<USP_HotelStatus_Select_Result> getRoomDashboardDetails(string RoomNo)
        {
            if (RoomNo == null)
                RoomNo = "";
            
            return objapi.USP_HotelStatus_Select(RoomNo).AsEnumerable();
        }

        // Para inserir / atualizar reserva de sala
        [HttpGet]
        public IEnumerable<string> insertRoomBooking(string BookingID, string RoomID, string BookedDateFR, string BookedDateTO, string BookingStatus, string PaymentStatus, string AdvancePayed, string TotalAmountPayed)
        {
            if (BookingID == null)
                BookingID = "0";

            if (RoomID == null)
                RoomID = "0";

            if (BookedDateFR == null)
            {
                BookedDateFR = "";
            }
                else
            {
                BookedDateFR = BookedDateFR.Substring(0, 10);
            }

            if (BookedDateTO == null)
            {
                BookedDateTO = "";
            }
            else
            {
                BookedDateTO = BookedDateTO.Substring(0, 10);
            }

            if (BookingStatus == null)
                BookingStatus = "";

            if (PaymentStatus == null)
                PaymentStatus = "";

            if (AdvancePayed == null)
                AdvancePayed = "";

            if (TotalAmountPayed == null)
                TotalAmountPayed = "";

            return objapi.USP_RoomBooking_Insert(BookingID, RoomID, BookedDateFR, BookedDateTO, BookingStatus, PaymentStatus, AdvancePayed, TotalAmountPayed).AsEnumerable();

        }
        // Para Excluir Detalhes da Música
        [HttpGet]
        public IEnumerable<string> deleteROom(string BookingID)
        {
            if (BookingID == null)
                BookingID = "0";

            return objapi.USP_RoomBooking_Delete(BookingID).AsEnumerable();

        }
    }
}
