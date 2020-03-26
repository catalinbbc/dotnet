namespace LinqAndLamdaExpressions
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Models;

    internal class Program
    {
        private static void Main(string[] args)
        {
            List<User> allUsers = ReadUsers("users.json");
            List<Post> allPosts = ReadPosts("posts.json");

            #region Demo

            // 1 - find all users having email ending with ".net".
            var users1 = from user in allUsers
                         where user.Email.EndsWith(".net")
                         select user;

            var users11 = allUsers.Where(user => user.Email.EndsWith(".net"));

            IEnumerable<string> userNames = from user in allUsers
                                            select user.Name;

            var userNames2 = allUsers.Select(user => user.Name);

            foreach (var value in userNames2)
            {
                Console.WriteLine(value);
            }

            IEnumerable<Company> allCompanies = from user in allUsers
                                                select user.Company;

            var users2 = from user in allUsers
                         orderby user.Email
                         select user;

            var netUser = allUsers.First(user => user.Email.Contains(".net"));
            Console.WriteLine(netUser.Username);

            #endregion

            // 2 - find all posts for users having email ending with ".net".
            IEnumerable<int> usersIdsWithDotNetMails = from user in allUsers
                                                       where user.Email.EndsWith(".net")
                                                       select user.Id;

            IEnumerable<Post> posts = from post in allPosts
                                      where usersIdsWithDotNetMails.Contains(post.UserId)
                                      select post;

            foreach (var post in posts)
            {
                Console.WriteLine("PostId = " + post.Id + " " + "user: " + post.UserId);
            }


            // 3 - print number of posts for each user.

            Console.WriteLine("\n############### EX 3  Number of posts for every user :##############");



            var postGroups = (from post in allPosts
                              group post by post.UserId into g
                              select new
                              {
                                  c = g.Key,
                                  count = g.Count(),
                              }).OrderByDescending(c => c.count);

            foreach (var x in postGroups)
            {
                var userX = allUsers.Single(u => u.Id == x.c);
                Console.WriteLine("User Name : " + userX.Name + ": " + x.count);
            }





            // 4 - find all users that have lat and long negative.
            Console.WriteLine("\n############### EX 4 find all users that have lat and long negative :##############");
            IEnumerable<User> usersWithNegativeCoord = from user in allUsers
                                                       where user.Address.Geo.Lat < 0
                                                       where user.Address.Geo.Lng < 0
                                                       select user;
            foreach (var user in usersWithNegativeCoord)
            {
                Console.WriteLine("User " + user.Name + "Has Negative Coord: [" + user.Address.Geo.Lat + "," + user.Address.Geo.Lng +"]" );
            }


            //############################
            // 5 - find the post with longest body.
            // 6 - print the name of the employee that have post with longest body.
            Console.WriteLine("\n############### EX 5  find the post with longest body. + 6 (find UserName) :##############");

            var longestPost = allPosts
                                    .OrderByDescending(post => post.Body.Length)
                                    .Select(post => new { post.Id, post.Body.Length, post.UserId });
            //get the user details
            var theUser = allUsers.Single(u => u.Id == longestPost.First().UserId);
            Console.WriteLine("The longest post is with ID = {0} Length: {1} by {2}", longestPost.First().Id, longestPost.First().Length, theUser.Name);


            // 7 - select all addresses in a new List<Address>. print the list.
            Console.WriteLine("\n############### EX 7 - select all addresses in a new List<Address>. print the list. :##############");

            var addressList =
                            (from user in allUsers
                             select new 
                             {
                                 user.Name,
                                 user.Address.City,
                                 user.Address.Street,
                                 user.Address.Suite,
                                 user.Address.Zipcode,
                                 user.Address.Geo

                             }
                            ).ToList();

           
            foreach( var userAddress in addressList)
            {
                Console.WriteLine("User {0} Address is: City {1}, Street {2}, Suite {3} , Zip {4}, Coord: {5} - {6}", 
                    userAddress.Name, userAddress.City, userAddress.Street, userAddress.Suite, userAddress.Zipcode, userAddress.Geo.Lat, userAddress.Geo.Lng
                    );
            }

            // 8 - print the user with min lat
            Console.WriteLine("\n############### EX 8 print the user with min lat. :##############");
            var theMinUser = allUsers.OrderBy(item => item.Address.Geo.Lat).First();
            Console.WriteLine("User with Min Lat is "+ theMinUser.Name +" at: "+ theMinUser.Address.Geo.Lat);

            // 9 - print the user with max long
            Console.WriteLine("\n############### 9 - print the user with max long. :##############");
            var theMaxUser = allUsers.OrderByDescending(item => item.Address.Geo.Lng).First();
            Console.WriteLine("User with Max Long is " + theMaxUser.Name + " at: " + theMaxUser.Address.Geo.Lng);

            // 10 - create a new class: public class UserPosts { public User User {get; set}; public List<Post> Posts {get; set} }
            //    - create a new list: List<UserPosts>
            //    - insert in this list each user with his posts only

            // 11 - order users by zip code
            Console.WriteLine("\n############### EX 11 - order users by zip code. :##############");

          var OrderedUsers = allUsers.OrderBy(o => o.Address.Zipcode).ToList();
            foreach (var user in OrderedUsers)
            {
                Console.WriteLine("User {0} is at zip {1}", user.Name, user.Address.Zipcode);
            }    

            // 12 - order users by number of posts
            //done on ex3
        }

        private static List<Post> ReadPosts(string file)
        {
            return ReadData.ReadFrom<Post>(file);
        }

        private static List<User> ReadUsers(string file)
        {
            return ReadData.ReadFrom<User>(file);
        }

        public class UserPosts
        {
            public List<User> User { get; set; }
            public List<Post> Posts { get; set; }
        }
    }
}
