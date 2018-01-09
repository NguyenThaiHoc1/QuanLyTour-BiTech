using System;

using System.Collections.Generic;
using Core.Model;

namespace SystemTourBitech.Models
{
    public class MessageBill
    {

        public bool Status { get; set; }

        public List<HoaDon> listhoadontimkiem { get; set; }
    }
}
