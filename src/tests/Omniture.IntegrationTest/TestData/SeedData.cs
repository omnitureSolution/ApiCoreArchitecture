//using System;
//using System.Collections.Generic;
//using Omniture.Db.Abstractions.Enums;
//using Omniture.Db.Context;
//using Omniture.Db.Entity.Account;
//using Omniture.Db.Entity.Database;
//using Omniture.Db.Entity.Enquiries;

//namespace Omniture.IntegrationTest.TestData
//{
//    public class SeedData
//    {

//        public static void PopulateTestData(SocietyCareContext visionDb)
//        {
//            visionDb.Users.Add(new Users
//            {
//                UserName = "admin",
//                UserPassword =
//                                                        new List<UserPassword> { new UserPassword { Password = "admin" } }
//            });
//            visionDb.Users.Add(new Users
//            {
//                UserName = "superuser",
//                UserPassword =
//                                                        new List<UserPassword> { new UserPassword { Password = "superuser" } }
//            });
//            visionDb.Users.Add(new Users
//            {
//                UserName = "deleteuser",
//                UserPassword =
//                                                        new List<UserPassword> { new UserPassword { Password = "deleteuser" } }
//            });
//            visionDb.Users.Add(new Users
//            {
//                UserName = "updateuser",
//                UserPassword =
//                                                        new List<UserPassword> { new UserPassword { Password = "updateuser" } }
//            });
//            visionDb.Users.Add(new Users
//            {
//                UserName = "user5",
//                UserPassword =
//                                                        new List<UserPassword> { new UserPassword { Password = "user5" } }
//            });

//            visionDb.SaveChanges();

//            visionDb.Address.Add(new Address
//            {
//                AddressLine1 = "Address line 1",
//                AddressLine2 = "Address line 2",
//                AddressTypeId = AddressTypes.EnquiryRental,
//                County = "U.K.",
//                Postcode = "EN4 22A",
//                PostcodePart1 = "EN4",
//                PostcodePart2 = "22A",
//                Town = "Town"
//            });

//            visionDb.Address.Add(new Address
//            {
//                AddressLine1 = "Address line 1 for address 2",
//                AddressLine2 = "Address line 2 for address 2",
//                AddressTypeId = AddressTypes.TenantCurrent,
//                County = "U.K.",
//                Postcode = "EN4 32C",
//                PostcodePart1 = "EN4",
//                PostcodePart2 = "32C",
//                Town = "Town"
//            });

//            visionDb.Address.Add(new Address
//            {
//                AddressLine1 = "Address line 1 for address 3",
//                AddressLine2 = "Address line 2 for address 3",
//                AddressTypeId = AddressTypes.EnquiryRental,
//                County = "U.K.",
//                Postcode = "EN4 55A",
//                PostcodePart1 = "EN4",
//                PostcodePart2 = "55A",
//                Town = "Town"
//            });

//            visionDb.Address.Add(new Address
//            {
//                AddressLine1 = "Address line 1 for address 4",
//                AddressLine2 = "Address line 2 for address 4",
//                AddressTypeId = AddressTypes.EnquiryRental,
//                County = "U.K.",
//                Postcode = "EN4 999",
//                PostcodePart1 = "EN4",
//                PostcodePart2 = "999",
//                Town = "Town",
//                //Contact = new List<Contact>()
//                //{
//                //     new Contact{
//                //         ContactTypeId =  ContactTypes.Email,
//                //          ContactInfo="test@t.com"
//                //        },
//                //     new Contact{
//                //         ContactTypeId =  ContactTypes.Phone,
//                //          ContactInfo="5823568945"
//                //        }
//                //}
//            });
//            visionDb.SaveChanges();
//            SeedTenantTestData(visionDb);
//            SeedEnquryTestData(visionDb);
//            visionDb.DetachGraph();
//        }

//        static void SeedTenantTestData(SocietyCareContext visionDb)
//        {
//            visionDb.Tenant.Add(new Tenant
//            {
//                EntryFrom = EntryTypes.Backoffice,
//                DateOfBirth = DateTime.Now.AddYears(-25),
//                Forename = "Hitesh",
//                Surname = "Patel",
//                TitleId = 1,
//                IsGdprmarkActive = false
//            });

//            visionDb.Tenant.Add(new Tenant
//            {
//                EntryFrom = EntryTypes.Backoffice,
//                DateOfBirth = DateTime.Now.AddYears(-18),
//                Forename = "Hitesh 1",
//                Surname = "Patel",
//                TitleId = 2,
//                IsGdprmarkActive = true,
//                GdprmarkPermDate = new DateTime()
//            });

//            visionDb.Tenant.Add(new Tenant
//            {
//                EntryFrom =  EntryTypes.InsurancePortal,
//                DateOfBirth = DateTime.Now.AddYears(-40),
//                Forename = "Hitesh 2",
//                Surname = "Patel",
//                TitleId = 2,
//                IsGdprmarkActive = true,
//                GdprmarkPermDate = new DateTime()
//            });

//            visionDb.Tenant.Add(new Tenant
//            {
//                EntryFrom = EntryTypes.InsurancePortal,
//                DateOfBirth = DateTime.Now.AddYears(-40),
//                Forename = "Hitesh 3",
//                Surname = "Patel",
//                TitleId = 1,
//                IsGdprmarkActive = false
//            });

//            visionDb.SaveChanges();
//        }
//        static void SeedEnquryTestData(SocietyCareContext visionDb)
//        {
//            visionDb.Enquiry.Add(new Db.Entity.Enquiries.Enquiry
//            {
//                EnquiryNumber = "00001",
//                EnquiryTypeId = EnquiryTypes.Insurance

//            });

//            visionDb.Enquiry.Add(new  Db.Entity.Enquiries.Enquiry
//            {
//                EnquiryNumber = "00002",
//                EnquiryTypeId = EnquiryTypes.Insurance

//            });

//            visionDb.Enquiry.Add(new  Db.Entity.Enquiries.Enquiry
//            {
//                EnquiryNumber = "00003",
//                EnquiryTypeId = EnquiryTypes.Referncing
//            });

//            visionDb.Enquiry.Add(new  Db.Entity.Enquiries.Enquiry
//            {
//                EnquiryNumber = "00004",
//                EnquiryTypeId = EnquiryTypes.Referncing
//            });

//            visionDb.SaveChanges();
//        }
//    }
//}
