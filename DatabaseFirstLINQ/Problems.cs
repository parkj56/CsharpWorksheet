using System;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using DatabaseFirstLINQ.Models;

namespace DatabaseFirstLINQ
{
    class Problems
    {
        private ECommerceContext _context;

        public Problems()
        {
            _context = new ECommerceContext();
        }
        public void RunLINQQueries()
        {
            //ProblemOne();
            //ProblemTwo();
            //ProblemThree();
            //ProblemFour();
            //ProblemFive();
            //ProblemSix();
            //ProblemSeven();
            //ProblemEight();
            //ProblemNine();
            //ProblemTen();
            //ProblemEleven();
            //ProblemTwelve();
            //ProblemThirteen();
            ProblemFourteen();
            //ProblemFifteen();
            //ProblemSixteen();
            //ProblemSeventeen();
            //ProblemEighteen();
            //ProblemNineteen();
            //ProblemTwenty();
        }

        // <><><><><><><><> R Actions (Read) <><><><><><><><><>
        private void ProblemOne()
        {
            // Write a LINQ query that returns the number of users in the Users table.
            // HINT: .ToList().Count

            var users = _context.Users.ToList().Count;
            Console.WriteLine(users);

            //var userNum =
            //    from u in users
            //    orderby u.ToList(users).Count;


            

        }

        private void ProblemTwo()
        {
            // Write a LINQ query that retrieves the users from the User tables then print each user's email to the console.
            var users = _context.Users;

            foreach (User user in users)
            {
                Console.WriteLine(user.Email);
            }

        }

        private void ProblemThree()
        {
            var products = _context.Products;

            var priceProducts = products.Where(p => p.Price > 150);
            foreach (var product in priceProducts)
            {
                Console.WriteLine(product.Name + " " + product.Price);
            }
         
        }

        private void ProblemFour()
        {
            // Write a LINQ query that gets each product that contains an "s" in the products name.
            // Then print the name of each product from the above query to the console.
            var products = _context.Products;
            foreach (var product in products)
            {
                var productName = product.Name.Contains('s');
                if (productName == true)
                {
                    Console.WriteLine(product.Name);
                }

            }

        }



        private void ProblemFive()
        {
            // Write a LINQ query that gets all of the users who registered BEFORE 2016
            // Then print each user's email and registration date to the console.
            var users = _context.Users;
            foreach (var user in users)
            {
                DateTime startDate = (DateTime)user.RegistrationDate;
                DateTime endDate = new DateTime(2015, 12, 31);
                if (startDate <= endDate)
                {
                    Console.WriteLine(user.Email + " " + user.RegistrationDate);
                }

            }

        }

        private void ProblemSix()
        {
            // Write a LINQ query that gets all of the users who registered AFTER 2016 and BEFORE 2018
            // Then print each user's email and registration date to the console.
            var users = _context.Users;
            foreach (var user in users)
            {
                DateTime betweenDate = (DateTime)user.RegistrationDate;
                DateTime endDate= new DateTime(2017, 12, 31);
                DateTime StartDate = new DateTime(2016, 01, 01);
                if (betweenDate > StartDate && betweenDate < endDate)
                {
                    Console.WriteLine(user.Email + " " + user.RegistrationDate);

                }

            }
        }

        // <><><><><><><><> R Actions (Read) with Foreign Keys <><><><><><><><><>

        private void ProblemSeven()
        {
            // Write a LINQ query that retreives all of the users who are assigned to the role of Customer.
            // Then print the users email and role name to the console.
            var customerUsers = _context.UserRoles.Include(ur => ur.Role).Include(ur => ur.User).Where(ur => ur.Role.RoleName == "Customer");
            foreach (UserRole userRole in customerUsers)
            {
                Console.WriteLine($"Email: {userRole.User.Email} Role: {userRole.Role.RoleName}");
            }
        }
       
        private void ProblemEight()
        // Write a LINQ query that retreives all of the products in the shopping cart of the user who has the email "afton@gmail.com".
        // Then print the product's name, price, and quantity to the console.
        {     
            var userProducts = _context.ShoppingCarts
                                       .Include(ur => ur.User)
                                       .Where(ue => ue.User.Email == "afton@gmail.com")
                                       .Include(pn => pn.Product);


            foreach (var product in userProducts)
            {
                Console.WriteLine($"product Name: {product.Product.Name} Price: {product.Product.Price} Quantity: {product.Quantity}");
            }
        }

        private void ProblemNine()
            // Write a LINQ query that retreives all of the products in the shopping cart of the user who has the email "oda@gmail.com" and returns the sum of all of the products prices.
            // HINT: End of query will be: .Select(sc => sc.Product.Price).Sum();
            // Then print the total of the shopping cart to the console.
        {
            var totalPrice = _context.ShoppingCarts
                           .Include(ur => ur.User)
                           .Where(ue => ue.User.Email == "oda@gmail.com")
                           .Include(pn => pn.Product)
                           .Select(sc => sc.Product.Price).Sum();
            {
                Console.WriteLine($"Total Price: {totalPrice}");
            }



        }

        private void ProblemTen()
        {
            //    // Write a LINQ query that retreives all of the products in the shopping cart of users who have the role of "Employee".
            //    // Then print the user's email as well as the product's name, price, and quantity to the console
            //    var userProducts = _context.ShoppingCarts;
            //    var userRole = _context.UserRoles

            //        .Include(ur => ur.User)
            //        .Where(ur => ur.Role.RoleName == "Employee");
            //    //.Where(pd => pd.Product)
            //    //.Include(pr => pr.UserProducts);

            //    foreach (var product in userProducts)
            //    {
            //        Console.WriteLine($"Email: {userRole.User.Email} Product Name:{product.Product.Name} Price: {product.Product.Price} Quantity: {userProducts.Quantity}");

            //    }
        }

    
        // <><><><><><><><> CUD (Create, Update, Delete) Actions <><><><><><><><><>

        // <><> C Actions (Create) <><>

        private void ProblemEleven()
        {
            // Create a new User object and add that user to the Users table using LINQ.
            User newUser = new User()
            {
                Email = "david@gmail.com",
                Password = "DavidsPass123"
            };
            _context.Users.Add(newUser);
            _context.SaveChanges();
        }

        private void ProblemTwelve()
        {
            // Create a new Product object and add that product to the Products table using LINQ.
            Product newProduct = new Product()
            {
                Name = "Samsung Z Fold 3",
                Description = "Samsung Z Fold 3 Cell Phone",
                Price = (1800)
            };
            _context.Products.Add(newProduct);
            _context.SaveChanges();
        }

        private void ProblemThirteen()
        {
            // Add the role of "Customer" to the user we just created in the UserRoles junction table using LINQ.
            var roleId = _context.Roles.Where(r => r.RoleName == "Customer").Select(r => r.Id).SingleOrDefault();
            var userId = _context.Users.Where(u => u.Email == "david@gmail.com").Select(u => u.Id).SingleOrDefault();
            UserRole newUserRole = new UserRole()
            {
                UserId = userId,
                RoleId = roleId
            };
            _context.UserRoles.Add(newUserRole);
            _context.SaveChanges();
        }

        private void ProblemFourteen()
        {
            // Add the product you create to the user we created in the ShoppingCart junction table using LINQ.
            var userCart = _context.ShoppingCarts.Where(u => u.UserId == (6)).Select(p => p.ProductId).SingleOrDefault();
            ShoppingCart newShoppingCart = new ShoppingCart()
                {
                   UserId = userCart,
                   ProductId= 8
                    
                };
        _context.ShoppingCarts.Add(newShoppingCart);
        _context.SaveChanges();

        }

        // <><> U Actions (Update) <><>

        private void ProblemFifteen()
        {
            // Update the email of the user we created to "mike@gmail.com"
            var user = _context.Users.Where(u => u.Email == "david@gmail.com").SingleOrDefault();
            user.Email = "mike@gmail.com";
            _context.Users.Update(user);
            _context.SaveChanges();
        }

        private void ProblemSixteen()
        {
            // Update the price of the product you created to something different using LINQ.

        }

        private void ProblemSeventeen()
        {
            // Change the role of the user we created to "Employee"
            // HINT: You need to delete the existing role relationship and then create a new UserRole object and add it to the UserRoles table
            // See problem eighteen as an example of removing a role relationship
            var userRole = _context.UserRoles.Where(ur => ur.User.Email == "mike@gmail.com").SingleOrDefault();
            _context.UserRoles.Remove(userRole);
            UserRole newUserRole = new UserRole()
            {
                UserId = _context.Users.Where(u => u.Email == "mike@gmail.com").Select(u => u.Id).SingleOrDefault(),
                RoleId = _context.Roles.Where(r => r.RoleName == "Employee").Select(r => r.Id).SingleOrDefault()
            };
            _context.UserRoles.Add(newUserRole);
            _context.SaveChanges();
        }

        // <><> D Actions (Delete) <><>

        private void ProblemEighteen()
        {
            // Delete the role relationship from the user who has the email "oda@gmail.com" using LINQ.

        }

        private void ProblemNineteen()
        {
            // Delete all of the product relationships to the user with the email "oda@gmail.com" in the ShoppingCart table using LINQ.
            // HINT: Loop
            var shoppingCartProducts = _context.ShoppingCarts.Where(sc => sc.User.Email == "oda@gmail.com");
            foreach (ShoppingCart userProductRelationship in shoppingCartProducts)
            {
                _context.ShoppingCarts.Remove(userProductRelationship);
            }
            _context.SaveChanges();
        }

        private void ProblemTwenty()
        {
            // Delete the user with the email "oda@gmail.com" from the Users table using LINQ.

        }

        // <><><><><><><><> BONUS PROBLEMS <><><><><><><><><>

        private void BonusOne()
        {
            // Prompt the user to enter in an email and password through the console.
            // Take the email and password and check if the there is a person that matches that combination.
            // Print "Signed In!" to the console if they exists and the values match otherwise print "Invalid Email or Password.".
        }

        private void BonusTwo()
        {
            // Write a query that finds the total of every users shopping cart products using LINQ.
            // Display the total of each users shopping cart as well as the total of the toals to the console.
        }

        // BIG ONE
        private void BonusThree()
        {
            // 1. Create functionality for a user to sign in via the console
            // 2. If the user succesfully signs in
            // a. Give them a menu where they perform the following actions within the console
            // View the products in their shopping cart
            // View all products in the Products table
            // Add a product to the shopping cart (incrementing quantity if that product is already in their shopping cart)
            // Remove a product from their shopping cart
            // 3. If the user does not succesfully sing in
            // a. Display "Invalid Email or Password"
            // b. Re-prompt the user for credentials

        }

    }
}
