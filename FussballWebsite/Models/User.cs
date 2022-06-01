using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Fussball_Website.Models {
    public class User {

        private int userID;
        public int UserID {
            get { return this.userID; }
            set {
                if (value >= 0) {
                    this.userID = value;
                }
            }
        }
        public string Username { get; set; }
        public string Password { get; set; }
        public string EMail { get; set; }
        public DateTime Birthdate { get; set; }
        public Gender Gender { get; set; }
        public Liga Liga { get; set; }
        public Role Role { get; set; }

    }

}