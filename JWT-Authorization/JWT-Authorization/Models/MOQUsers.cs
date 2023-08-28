namespace JWT_Authorization.Models;

public static class MOQUsers
{

    public static List<Users> AllUsers()
    {
        return new List<Users>()
        {
            new Users() { FirstName ="userFname1",LastName="UserLname1",Email="user1@mail.com",Password="12345"  },
            new Users() { FirstName ="userFname2",LastName="UserLname2",Email="user2@mail.com",Password="54321"  },
            new Users() { FirstName ="userFname3",LastName="UserLname3",Email="user3@mail.com",Password="98765"  },
            new Users() { FirstName ="userFname4",LastName="UserLname4",Email="user4@mail.com",Password="67890"  },
        };
    }

}
