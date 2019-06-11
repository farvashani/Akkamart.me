using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Akkamart.Shared.Metadata
{
    public class NavigationState
    {
        
       public List<Metadata> TopNavigation { get; set; } = new List<Metadata>(){
                        new Metadata{Title = "Home", BaseUrl = "/home/", Actions= new List<ServiceAction>(){}},
                        new Metadata{Title = "Membership", 
                                    BaseUrl = "/membership/", 
                                    Actions = new List<ServiceAction>(){
                                        new ServiceAction(){
                                            Title = "Become a member",
                                            Description = "Become a member by register your mobile",
                                            Url=@"\register",
                                            Params = new List<ActionParam>(){
                                                new ActionParam(){Name = "Name", Type = typeof(string).ToString()},
                                                new ActionParam(){Name = "Mobile", Type = typeof(string).ToString()}
                                            }

                                        }, 
                                        new ServiceAction(){
                                            Title = "Verify your account",
                                            Description = "Verify your account by the verification code you received",
                                            Url=@"\verify",
                                             Params = new List<ActionParam>(){
                                                new ActionParam(){Name = "ConfirmMobile", Type = typeof(string).ToString()},
                                                new ActionParam(){Name = "ConfirmEmail", Type = typeof(string).ToString()}
                                            }

                                        },
                                        new ServiceAction(){
                                            Title = "Add Your Profile Info",
                                            Description = "Add your information to rich your profile",
                                            Url=@"\addprofile",
                                             Params = new List<ActionParam>(){
                                                new ActionParam(){Name = "Title", Type = typeof(string).ToString()},
                                                new ActionParam(){Name = "Firstname", Type = typeof(string).ToString()},
                                                new ActionParam(){Name = "Lastname", Type = typeof(string).ToString()}, 
                                                new ActionParam(){Name = "Address", Type = typeof(string).ToString()}, 
                                                new ActionParam(){Name = "Contact", Type = typeof(string).ToString()}, 
                                                new ActionParam(){Name = "Avatar", Type = typeof(File).ToString()}
                                            }
                                        },
                                         
                                        new ServiceAction(){
                                            Title = "Set a credential for your account",
                                            Description = "Set an username and password for your account",
                                            Url=@"\setcredential",
                                             Params = new List<ActionParam>(){
                                                new ActionParam(){Name = "Username", Type = typeof(string).ToString()},
                                                new ActionParam(){Name = "NewPassword", Type = typeof(string).ToString()},
                                                new ActionParam(){Name = "ConfirmNewPassword", Type = typeof(string).ToString()}
                                            }

                                        }, 
                                        new ServiceAction(){
                                            Title = "Forget your password",
                                            Description = "Reset your password",
                                            Url=@"\ResetPassword",
                                             Params = new List<ActionParam>(){
                                                new ActionParam(){Name = "NewPassword", Type = typeof(string).ToString()},
                                                new ActionParam(){Name = "ConfirmNewPassword", Type = typeof(string).ToString()}
                                            }

                                        },  
                                        
                                    },
                                    
                                    }
                    };

    }
}