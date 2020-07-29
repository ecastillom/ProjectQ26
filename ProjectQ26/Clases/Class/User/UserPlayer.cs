using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;


public class UserPlayer
{
    public UserPlayer()
    {

    }
    public Int32 idUser { get; set; }
    public string UserName { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public DateTime DateOfBirth { get; set; }
    public string Email { get; set; }
    public int idSecurityUser { get; set; }
    public string SecurityUserDescr { get; set; }
    public string DateAdd { get; set; }
    public bool Active { get; set; }
    public string UserPassword { get; set; }

}
