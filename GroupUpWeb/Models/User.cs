using GroupUpWeb.BusinessInterface;
using GroupUpWeb.Helpers.Business;
using GroupUpWeb.Helpers.Uow;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace GroupUpWeb.Models
{
    public class User : BusinessBase, IUser
    {
        public int UserID { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string Token { get; set; }
        public DateTime SigninDate { get; set; }
        public DateTime LastLogin { get; set; }


        public User(IUnityOfWork uow) : base(uow)
        {
            
        }

        public void Create(User user)
        {
            Name = user.Name;
            LastName = user.LastName;
            Email = user.Email;
            Password = user.Password; //TODO HASH
            Token = GetToken();
            SigninDate = DateTime.Now;
            LastLogin = DateTime.Now;
            Uow.User.Add(this);
        }
        public void Delete()
        {
            Uow.User.Delete(this);
        }

        public void EditName(string name) {
            Name = name;
            Update();
        }

        public void EditLastName(string lastName) {
            LastName = lastName;
            Update();
        }

        public void EditEmail(string email) {
            Email = email;
            Update();
        }

        public void EditPassword(string password) {
            Password = password; // TODO Confirm 
            Update();
        }

        public void GenerateToken() {
            Token = "GENERATED+TOKEN"; // TODO create a token
        }

        public string GetToken() {
            if (Token == null)  //TODO confirm that its still valid
                GenerateToken();
            return Token;
        }

        public void UpdateLoginDate() {
            LastLogin = DateTime.Now;
            Update();
        }
        private void Update() {
            Uow.User.Update(this);
        }
    }
}