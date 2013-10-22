﻿using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiSample.DA.Tables.DatabaseInitializer
{
    public class DefaultConfiguration : DbMigrationsConfiguration<ShopContext>
    {
        public DefaultConfiguration()
        {
            AutomaticMigrationsEnabled = true;
        }

        protected override void Seed(ShopContext context)
        {
            context.Users.AddOrUpdate(
                i => i.Name,
                new User()
                {
                    Name = "Kirk",
                    Email = "kirkchen@test.com",
                    Token = "123456",
                    EncryptKey = "1111",
                    Groups = new List<Group>()
                    {
                        new Group(){
                            Name="Administrator"
                        },
                        new Group(){
                            Name= "User"
                        }
                    }
                },
                new User()
                {
                    Name = "John",
                    Email = "john@test.com",
                    Token = "222222",
                    EncryptKey = "2222",
                    Groups = new List<Group>()
                    {
                        new Group(){
                            Name="Administrator"
                        },
                        new Group(){
                            Name= "User"
                        }
                    }
                }
            );

        }
    }
}
