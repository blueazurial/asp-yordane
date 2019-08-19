using DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication1.Utils
{
    public class Session
    {
        public bool IsLogged
        {
            get
            {
                object value = HttpContext.Current.Session["IsLogged"];
                return ((bool?)value) ?? false;
            }
            set
            {
                HttpContext.Current.Session["IsLogged"] = value;
            }
        }
        public User ConnectedUser
        {
            get
            {
                object value
                    = HttpContext.Current.Session["ConnectedUser"];
                return (User)value;
            }
            set
            {
                HttpContext.Current.Session["ConnectedUser"] = value;
            }
        }
        private static Session _Instance;
        public static Session Instance
        {
            get
            {
                if(_Instance == null)
                {
                    _Instance = new Session();
                }
                return _Instance;
            }

        }
        private Session()
        {

        }

        public void Logout()
        {
            IsLogged = false;
            ConnectedUser = null;
        }
    }
}