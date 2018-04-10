using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using SmartChickAPI.Model;

namespace SmartChickAPI
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "SmartChickImp" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select SmartChickImp.svc or SmartChickImp.svc.cs at the Solution Explorer and start debugging.
    public class SmartChickImp : ISmartChickImp
    {

        #region Demo
        public string Demo(string Id)
        {
            return "Hello " + Id;
        }
        #endregion

        #region User 
        public wsUser GetUser(string Email)
        {
            NanoFarmDataContext dc = new NanoFarmDataContext();
            var userModel = dc.Users.Where(user => user.Email == Email).FirstOrDefault();
            if (userModel != null)
            {
                wsUser result = new wsUser()
                {
                    Email = userModel.Email,
                    Name = userModel.Name,
                    Picture = userModel.Picture,
                    Sexual = userModel.Sexual.Value,
                    YearOld = userModel.YearOld.Value,
                    Password = userModel.Password
                    
                };
                return result;
            }
            else
            {
                return null;
            }
        }
        public List<wsUser> GetAllUsers()
        {
            try
            {
                NanoFarmDataContext dc = new NanoFarmDataContext();
                List<wsUser> result = new List<wsUser>();
                foreach (User user in dc.Users)
                {
                    result.Add(new wsUser()
                    {
                        Email = user.Email,
                        Name = user.Name,
                        Sexual = user.Sexual.Value,
                        YearOld = user.YearOld.Value,
                        Picture = user.Picture,
                        Password = user.Password

                    });
                }
                return result;
            }
            catch (Exception ex)
            {
                return null;
            }


        }
        public string InsertUser(string email, string name, string sexual, string yearOld, string picture, string password)
        {
            try
            {
                User user = new User()
                {
                    Email = email,
                    Name = name,
                    Picture = picture,
                    Sexual = Convert.ToBoolean(sexual),
                    YearOld = Convert.ToInt32(yearOld),
                    Password = password
                };

                using (var nano = new NanoFarmDataContext())
                {
                    nano.Users.InsertOnSubmit(user);
                    nano.SubmitChanges();
                }
                return "Success";
            }
            catch(Exception ex)
            {
                return "Error: " + ex.Message;
            }

        }
        public string UpdateUser(string email, string name, string sexual, string yearOld, string picture, string password)
        {
            try
            {
                using (var nano = new NanoFarmDataContext())
                {
                    var user = nano.Users.Where(s => s.Email == email).FirstOrDefault();

                    user.Name = name;
                    user.Picture = picture;
                    user.Sexual = Convert.ToBoolean(sexual);
                    user.YearOld = Convert.ToInt32(yearOld);
                    user.Password = password;

                    nano.SubmitChanges();
                }
                    
                return "Success";
            }
            catch (Exception ex)
            {
                return "Error: " + ex.Message;
            }
        }
        public string DeleteUser(string email)
        {
            try
            {
                using (var nano = new NanoFarmDataContext())
                {
                    var user = nano.Users.Where(s => s.Email == email).FirstOrDefault();

                    nano.Users.DeleteOnSubmit(user);
                    nano.SubmitChanges();
                }
                return "Success";
            }
            catch (Exception ex)
            {
                return "Error: " + ex.Message;
            }
        }
        #endregion

        #region Hub Information
        public List<wsHubInformation> GetAllHubInformation()
        {
            try
            {
                NanoFarmDataContext dc = new NanoFarmDataContext();
                List<wsHubInformation> result = new List<wsHubInformation>();
                foreach (Hub_Information hub in dc.Hub_Informations)
                {
                    result.Add(new wsHubInformation()
                    {
                        ID = hub.ID,
                        Name = hub.Name,
                        Location = hub.Location,
                        Email = hub.Email

                    });
                }
                return result;
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        public wsHubInformation GetHub(string ID)
        {
            NanoFarmDataContext dc = new NanoFarmDataContext();
            var hubModel = dc.Hub_Informations.Where(hub => hub.ID == ID).FirstOrDefault();
            if (hubModel != null)
            {
                wsHubInformation result = new wsHubInformation()
                {
                    ID = hubModel.ID,
                    Name = hubModel.Name,
                    Location = hubModel.Location,
                    Email = hubModel.Email
                };
                return result;
            }
            else
            {
                return null;
            }
        }
        public wsHubInformation GetHubByEmail(string email)
        {
            NanoFarmDataContext dc = new NanoFarmDataContext();
            var hubModel = dc.Hub_Informations.Where(hub => hub.Email == email).FirstOrDefault();
            if (hubModel != null)
            {
                wsHubInformation result = new wsHubInformation()
                {
                    ID = hubModel.ID,
                    Name = hubModel.Name,
                    Location = hubModel.Location,
                    Email = hubModel.Email
                };
                return result;
            }
            else
            {
                return null;
            }
        }


        public string InsertHub(string id, string name, string location, string email)
        {
            try
            {
                Hub_Information hub = new Hub_Information()
                {
                    ID = id,
                    Name = name,
                    Location = location,
                    Email = email

                };

                using (var nano = new NanoFarmDataContext())
                {
                    nano.Hub_Informations.InsertOnSubmit(hub);
                    nano.SubmitChanges();
                }
                return "Success";
            }
            catch (Exception ex)
            {
                return "Error: " + ex.Message;
            }
        }

        public string UpdateHub(string id, string name, string location, string email)
        {
            try
            {
                using (var nano = new NanoFarmDataContext())
                {
                    var hub = nano.Hub_Informations.Where(s => s.ID == id).FirstOrDefault();

                    hub.Name = name;
                    hub.Location = location;
                    hub.Email = email;

                    nano.SubmitChanges();
                }



                return "Success";
            }
            catch (Exception ex)
            {
                return "Error: " + ex.Message;
            }
        }

        public string DeleteHub(string id)
        {
            try
            {
                using (var nano = new NanoFarmDataContext())
                {
                    var hub = nano.Hub_Informations.Where(s => s.ID == id).FirstOrDefault();

                    nano.Hub_Informations.DeleteOnSubmit(hub);
                    nano.SubmitChanges();
                }



                return "Success";
            }
            catch (Exception ex)
            {
                return "Error: " + ex.Message;
            }
        }


        #endregion

        #region Action
        public List<wsAction> GetAllActions()
        {
            try
            {
                NanoFarmDataContext dc = new NanoFarmDataContext();
                List<wsAction> result = new List<wsAction>();
                foreach (Action action in dc.Actions)
                {
                    result.Add(new wsAction()
                    {
                        HubID = action.HubID,
                        Feed_Status = action.Feed_Status.Value,
                        Active_Status = action.Active_Status.Value,
                        Active_Speed = action.Active_Speed.Value,
                        Gate_Status = action.Gate_Status.Value,
                        Clean_Status = action.Clean_Status.Value,
                        Sterilise_Status = action.Clean_Status.Value,
                        Light_Status = action.Light_Status.Value

                    });
                }
                return result;
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        public wsAction GetAction(string HubID)
        {
            NanoFarmDataContext dc = new NanoFarmDataContext();
            var actionModel = dc.Actions.Where(action => action.HubID == HubID).FirstOrDefault();
            if (actionModel != null)
            {
                wsAction result = new wsAction()
                {
                    HubID = actionModel.HubID,
                    Feed_Status = actionModel.Feed_Status.Value,
                    Active_Status = actionModel.Active_Status.Value,
                    Active_Speed = actionModel.Active_Speed.Value,
                    Gate_Status = actionModel.Gate_Status.Value,
                    Clean_Status = actionModel.Clean_Status.Value,
                    Sterilise_Status = actionModel.Sterilise_Status.Value,
                    Light_Status = actionModel.Light_Status.Value
                };
                return result;
            }
            else
            {
                return null;
            }
        }
        public string InsertAction(string HubID, string Feed_Status, string Active_Status, string Active_Speed, string Gate_Status, string Clean_Status, string Sterilise_Status, string Light_Status)
        {
            try
            {
                Action action = new Action()
                {
                   HubID = HubID,
                   Feed_Status = Convert.ToBoolean(Feed_Status),
                   Active_Status = Convert.ToBoolean(Active_Status),
                   Active_Speed = Convert.ToInt32(Active_Speed),
                   Gate_Status = Convert.ToBoolean(Gate_Status),
                   Clean_Status = Convert.ToBoolean(Clean_Status),
                   Sterilise_Status = Convert.ToBoolean(Sterilise_Status),
                   Light_Status = Convert.ToBoolean(Light_Status)

                };

                using (var nano = new NanoFarmDataContext())
                {
                    nano.Actions.InsertOnSubmit(action);
                    nano.SubmitChanges();
                }
                return "Success";
            }
            catch (Exception ex)
            {
                return "Error: " + ex.Message;
            }
        }

        public string UpdateAction(string HubID, string Feed_Status, string Active_Status, string Active_Speed, string Gate_Status, string Clean_Status, string Sterilise_Status, string Light_Status)
        {
            try
            {
                using (var nano = new NanoFarmDataContext())
                {
                    var action = nano.Actions.Where(s => s.HubID == HubID).FirstOrDefault();

                    action.HubID = HubID;
                    action.Feed_Status = Convert.ToBoolean(Feed_Status);
                    action.Active_Status = Convert.ToBoolean(Active_Status);
                    action.Active_Speed = Convert.ToInt32(Active_Speed);
                    action.Gate_Status = Convert.ToBoolean(Gate_Status);
                    action.Clean_Status = Convert.ToBoolean(Clean_Status);
                    action.Sterilise_Status = Convert.ToBoolean(Sterilise_Status);
                    action.Light_Status = Convert.ToBoolean(Light_Status);

                    nano.SubmitChanges();
                }

                return "Success";
            }
            catch (Exception ex)
            {
                return "Error: " + ex.Message;
            }
        }

        public string DeleteAction(string HubID)
        {
            try
            {
                using (var nano = new NanoFarmDataContext())
                {
                    var action = nano.Actions.Where(s => s.HubID == HubID).FirstOrDefault();

                    nano.Actions.DeleteOnSubmit(action);
                    nano.SubmitChanges();
                }



                return "Success";
            }
            catch (Exception ex)
            {
                return "Error: " + ex.Message;
            }
        }




        #endregion

        #region Action Settings
        public List<wsActionSetting> GetAllActionSetting()
        {
            try
            {
                NanoFarmDataContext dc = new NanoFarmDataContext();
                List<wsActionSetting> result = new List<wsActionSetting>();
                foreach (Action_Setting item in dc.Action_Settings)
                {
                    result.Add(new wsActionSetting()
                    {
                        HubID = item.HubID,
                        Feed_Moment = item.Feed_Moment,
                        Feed_Mode = item.Feed_Mode.Value,
                        Active_Moment = item.Active_Moment,
                        Active_Speed = item.Active_Speed,
                        Active_Time = item.Active_Time,
                        Active_Mode = item.Active_Mode.Value,
                        Open_Gate = item.Open_Gate,
                        Close_Gate = item.Close_Gate,
                        Gate_Mode = item.Gate_Mode.Value,
                        Clean_Moment = item.Clean_Moment,
                        Clean_Mode = item.Clean_Mode.Value,
                        Sterilise_Mode = item.Sterilise_Mode.Value,
                        Sterilise_Moment_Day = item.Sterilise_Moment_Day,
                        Sterilise_Moment_Time = item.Sterilise_Moment_Time,
                        Light_Mode = item.Light_Mode.Value,
                        Light_Off_Time = item.Light_Off_Time,
                        Light_On_Time = item.Light_On_Time,

                    });
                }
                return result;
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        public wsActionSetting GetActionSettings(string HubID)
        {
            NanoFarmDataContext dc = new NanoFarmDataContext();
            var actionSettingModel = dc.Action_Settings.Where(acSet => acSet.HubID == HubID).FirstOrDefault();
            if (actionSettingModel != null)
            {
                wsActionSetting result = new wsActionSetting()
                {
                    HubID = actionSettingModel.HubID,
                    Feed_Mode = actionSettingModel.Feed_Mode.Value,
                    Feed_Moment = actionSettingModel.Feed_Moment,
                    Active_Mode = actionSettingModel.Active_Mode.Value,
                    Active_Moment = actionSettingModel.Active_Moment,
                    Active_Speed = actionSettingModel.Active_Speed,
                    Active_Time = actionSettingModel.Active_Time,
                    Open_Gate = actionSettingModel.Open_Gate,
                    Close_Gate = actionSettingModel.Close_Gate,
                    Gate_Mode = actionSettingModel.Gate_Mode.Value,
                    Clean_Mode = actionSettingModel.Clean_Mode.Value,
                    Clean_Moment = actionSettingModel.Clean_Moment,
                    Sterilise_Mode = actionSettingModel.Sterilise_Mode.Value,
                    Sterilise_Moment_Day = actionSettingModel.Sterilise_Moment_Day,
                    Sterilise_Moment_Time = actionSettingModel.Sterilise_Moment_Time,
                    Light_Mode = actionSettingModel.Light_Mode.Value,
                    Light_On_Time = actionSettingModel.Light_On_Time,
                    Light_Off_Time = actionSettingModel.Light_Off_Time,

                };
                return result;
            }
            else
            {
                return null;
            }
        }
        public string InsertActionSetting(string hubID, string Feed_Moment, string Feed_Mode, string Active_Moment, string Active_Speed, string Active_Time, string Active_Mode, string Open_Gate, string Close_Gate, string Gate_Mode, string Clean_Moment, string Clean_Mode, string Sterilise_Moment_Day, string Sterilise_Moment_Time, string Sterilise_Mode, string Light_Mode, string Light_On_Time, string Light_Off_time)
        {
            try
            {
                Action_Setting actionSetting = new Action_Setting()
                {

                    HubID = hubID,
                    Feed_Mode = Convert.ToBoolean(Feed_Mode),
                    Feed_Moment = Feed_Moment,
                    Active_Mode = Convert.ToBoolean(Active_Mode),
                    Active_Speed = Active_Speed,
                    Active_Time = Active_Time,
                    Active_Moment = Active_Moment,
                    Open_Gate = Open_Gate,
                    Close_Gate = Close_Gate,
                    Gate_Mode = Convert.ToBoolean(Gate_Mode),
                    Clean_Mode = Convert.ToBoolean(Clean_Mode),
                    Clean_Moment = Clean_Moment,
                    Sterilise_Mode = Convert.ToBoolean(Sterilise_Mode),
                    Sterilise_Moment_Day = Sterilise_Moment_Day,
                    Sterilise_Moment_Time = Sterilise_Moment_Time,
                    Light_Off_Time = Light_Off_time,
                    Light_On_Time = Light_On_Time,
                    Light_Mode = Convert.ToBoolean(Light_Mode)

                };

                using (var nano = new NanoFarmDataContext())
                {
                    nano.Action_Settings.InsertOnSubmit(actionSetting);
                    nano.SubmitChanges();
                }
                return "Success";
            }
            catch (Exception ex)
            {
                return "Error: " + ex.Message;
            }
        }

        public string UpdateActionSetting(string hubID, string Feed_Moment, string Feed_Mode, string Active_Moment, string Active_Speed, string Active_Time, 
                        string Active_Mode, string Open_Gate, string Close_Gate, string Gate_Mode, string Clean_Moment, string Clean_Mode, string Sterilise_Moment_Day, 
                        string Sterilise_Moment_Time, string Sterilise_Mode, string Light_Mode, string Light_On_Time, string Light_Off_time)
        {
            try
            {
                using (var nano = new NanoFarmDataContext())
                {
                    var actionSetting = nano.Action_Settings.Where(s => s.HubID == hubID).FirstOrDefault();

                    actionSetting.Feed_Mode = Convert.ToBoolean(Feed_Mode);
                    actionSetting.Feed_Moment = Feed_Moment;
                    actionSetting.Active_Mode = Convert.ToBoolean(Active_Mode);
                    actionSetting.Active_Moment = Active_Moment;
                    actionSetting.Active_Speed = Active_Speed;
                    actionSetting.Active_Time = Active_Time;
                    actionSetting.Open_Gate = Open_Gate;
                    actionSetting.Close_Gate = Close_Gate;
                    actionSetting.Gate_Mode = Convert.ToBoolean(Gate_Mode);
                    actionSetting.Clean_Mode = Convert.ToBoolean(Clean_Mode);
                    actionSetting.Clean_Moment = Clean_Moment;
                    actionSetting.Sterilise_Mode = Convert.ToBoolean(Sterilise_Mode);
                    actionSetting.Sterilise_Moment_Day = Sterilise_Moment_Day;
                    actionSetting.Sterilise_Moment_Time= Sterilise_Moment_Time;
                    actionSetting.Light_Off_Time = Light_Off_time;
                    actionSetting.Light_On_Time = Light_On_Time;
                    actionSetting.Light_Mode = Convert.ToBoolean(Light_Mode);

                    nano.SubmitChanges();
                }



                return "Success";
            }
            catch (Exception ex)
            {
                return "Error: " + ex.Message;
            }
        }

        public string DeleteActionSetting(string HubID)
        {
            try
            {
                using (var nano = new NanoFarmDataContext())
                {
                    var actionSetting = nano.Action_Settings.Where(s => s.HubID == HubID).FirstOrDefault();

                    nano.Action_Settings.DeleteOnSubmit(actionSetting);
                    nano.SubmitChanges();
                }

                return "Success";
            }
            catch (Exception ex)
            {
                return "Error: " + ex.Message;
            }
        }



        #endregion

        #region Chicken

        public List<wsChicken> GetAllChicken()
        {
            try
            {
                NanoFarmDataContext dc = new NanoFarmDataContext();
                List<wsChicken> result = new List<wsChicken>();
                foreach (Chicken chicken in dc.Chickens)
                {
                    result.Add(new wsChicken()
                    {
                        HubID = chicken.HubID,
                        Name = chicken.Name,
                        Quantity = chicken.Quantity.Value,
                        Outside = chicken.Outside.Value,
                        Inside = chicken.Inside.Value,
                        DayOld = chicken.DayOld,
                        Weight = chicken.Weight.Value,
                        BodyTemp = chicken.BodyTemp.Value,
                        SpeciesID = chicken.SpeciesID

                    });
                }
                return result;
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        public wsChicken GetChicken(string HubID)
        {
            NanoFarmDataContext dc = new NanoFarmDataContext();
            var chickenModel = dc.Chickens.Where(chicken => chicken.HubID == HubID).FirstOrDefault();
            if (chickenModel != null)
            {
                wsChicken result = new wsChicken()
                {
                    HubID = chickenModel.HubID,
                    Name = chickenModel.Name,
                    Quantity = chickenModel.Quantity.Value,
                    Outside = chickenModel.Outside.Value,
                    Inside = chickenModel.Inside.Value,
                    DayOld = chickenModel.DayOld,
                    Weight = chickenModel.Weight.Value,
                    BodyTemp = chickenModel.BodyTemp.Value,
                    SpeciesID = chickenModel.SpeciesID

                };
                return result;
            }
            else
            {
                return null;
            }
        }
        public string InsertChicken(string HubID, string spiecesID, string name, string dayold, string quantity, string outside, string inside, string weight, string bodytemp)
        {
            try
            {
                Chicken chicken = new Chicken()
                {

                    HubID = HubID,
                    SpeciesID = spiecesID,
                    Name = name,
                    Quantity = Convert.ToInt32(quantity),
                    Outside = Convert.ToInt32(outside),
                    Inside = Convert.ToInt32(inside),
                    DayOld = dayold,
                    Weight = Convert.ToInt32(weight),
                    BodyTemp = Convert.ToInt32(bodytemp)

                };

                using (var nano = new NanoFarmDataContext())
                {
                    nano.Chickens.InsertOnSubmit(chicken);
                    nano.SubmitChanges();
                }
                return "Success";
            }
            catch (Exception ex)
            {
                return "Error: " + ex.Message;
            }
        }
        public string UpdateChicken(string HubID, string spiecesID, string name, string dayold, string quantity, string outside, string inside, string weight, string bodytemp)
        {
            try
            {
                using (var nano = new NanoFarmDataContext())
                {
                    var chicken = nano.Chickens.Where(s => s.HubID == HubID).FirstOrDefault();

                    chicken.HubID = HubID;
                    chicken.Name = name;
                    chicken.Outside = Convert.ToInt32(outside);
                    chicken.Inside = Convert.ToInt32(inside);
                    chicken.Quantity = Convert.ToInt32(quantity);
                    chicken.DayOld = dayold;
                    chicken.BodyTemp = Convert.ToInt32(bodytemp);
                    chicken.Weight = Convert.ToInt32(weight);
                    chicken.SpeciesID = spiecesID;
                    nano.SubmitChanges();
                }



                return "Success";
            }
            catch (Exception ex)
            {
                return "Error: " + ex.Message;
            }
        }
        public string DeleteChicken(string HubID)
        {
            try
            {
                using (var nano = new NanoFarmDataContext())
                {
                    var chicken = nano.Chickens.Where(s => s.HubID == HubID).FirstOrDefault();

                    nano.Chickens.DeleteOnSubmit(chicken);
                    nano.SubmitChanges();
                }



                return "Success";
            }
            catch (Exception ex)
            {
                return "Error: " + ex.Message;
            }
        }

        #endregion

        #region Chicken List
        public List<wsChickenList> GetAllChickenList()
        {
            try
            {
                NanoFarmDataContext dc = new NanoFarmDataContext();
                List<wsChickenList> result = new List<wsChickenList>();
                foreach (Chicken_List chicken in dc.Chicken_Lists)
                {
                    result.Add(new wsChickenList()
                    {
                        Name = chicken.Name,
                        Picture = chicken.Picture,
                        SpeciesID = chicken.SpeciesID
                    });
                }
                return result;
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        public wsChickenList GetChickenList(string speciesID)
        {
            NanoFarmDataContext dc = new NanoFarmDataContext();
            var chickenModel = dc.Chicken_Lists.Where(chicken => chicken.SpeciesID == speciesID).FirstOrDefault();
            if (chickenModel != null)
            {
                wsChickenList result = new wsChickenList()
                {
                    Name = chickenModel.Name,
                    SpeciesID = chickenModel.SpeciesID,
                    Picture = chickenModel.Picture
                };
                return result;
            }
            else
            {
                return null;
            }
        }
        public string InsertChickenList(string SpecicesID, string Name, string Picture)
        {
            try
            {
                Chicken_List chickenList = new Chicken_List()
                {
                    SpeciesID = SpecicesID,
                    Name = Name,
                    Picture = Picture
                };

                using (var nano = new NanoFarmDataContext())
                {
                    nano.Chicken_Lists.InsertOnSubmit(chickenList);
                    nano.SubmitChanges();
                }
                return "Success";
            }
            catch (Exception ex)
            {
                return "Error: " + ex.Message;
            }
        }
        public string UpdateChickenList(string SpecicesID, string Name, string Picture)
        {
            try
            {
                using (var nano = new NanoFarmDataContext())
                {
                    var chickenList = nano.Chicken_Lists.Where(s => s.SpeciesID == SpecicesID).FirstOrDefault();

                    chickenList.SpeciesID = SpecicesID;
                    chickenList.Name = Name;
                    chickenList.Picture = Picture;

                    nano.SubmitChanges();
                }

                return "Success";
            }
            catch (Exception ex)
            {
                return "Error: " + ex.Message;
            }
        }
        public string DeleteChickenList(string HubID)
        {
            try
            {
                using (var nano = new NanoFarmDataContext())
                {
                    var chicken = nano.Chickens.Where(s => s.HubID == HubID).FirstOrDefault();

                    nano.Chickens.DeleteOnSubmit(chicken);
                    nano.SubmitChanges();
                }

                return "Success";
            }
            catch (Exception ex)
            {
                return "Error: " + ex.Message;
            }
        }
        #endregion

        #region ChickenLibrary

        public List<wsChickenLibrary> GetAllChickenLibrary()
        {
            try
            {
                NanoFarmDataContext dc = new NanoFarmDataContext();
                List<wsChickenLibrary> result = new List<wsChickenLibrary>();
                foreach (Chicken_Library chicken in dc.Chicken_Libraries)
                {
                    result.Add(new wsChickenLibrary()
                    {
                        TypeID = chicken.TypeID,
                        Name = chicken.Name,
                        Picture = chicken.Picture,
                        DayOld_Max = chicken.DayOld_Max.Value,
                        DayOld_Min = chicken.DayOld_Min.Value,
                        Food_Amount = chicken.Food_Amount.Value,
                        Food_Eat_No = chicken.Food_Eat_No.Value,
                        Humidity_Min = chicken.Humidity_Min.Value,
                        Humidity_Max = chicken.Humidity_Max.Value,
                        Lighting_Duration = chicken.Lighting_Duration,
                        Temperature_Min = chicken.Temperature_Min.Value,
                        Temperature_Max = chicken.Temperature_Max.Value,
                        Weight = chicken.Weight.Value,
                        SpeciesID = chicken.SpeciesID
                    });
                }
                return result;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public wsChickenLibrary GetChickenLibrary(string TypeID)
        {
            NanoFarmDataContext dc = new NanoFarmDataContext();
            var chickenModel = dc.Chicken_Libraries.Where(acSet => acSet.TypeID == TypeID).FirstOrDefault();
            if (chickenModel != null)
            {
                wsChickenLibrary result = new wsChickenLibrary()
                {
                    TypeID = chickenModel.TypeID,
                    Name = chickenModel.Name,
                    Picture = chickenModel.Picture,
                    DayOld_Max = chickenModel.DayOld_Max.Value,
                    DayOld_Min = chickenModel.DayOld_Min.Value,
                    Food_Amount = chickenModel.Food_Amount.Value,
                    Food_Eat_No = chickenModel.Food_Eat_No.Value,
                    Humidity_Min = chickenModel.Humidity_Min.Value,
                    Humidity_Max = chickenModel.Humidity_Max.Value,

                    Lighting_Duration = chickenModel.Lighting_Duration,
                    Temperature_Min = chickenModel.Temperature_Min.Value,
                    Temperature_Max = chickenModel.Temperature_Max.Value,

                    Weight = chickenModel.Weight.Value,
                    SpeciesID = chickenModel.SpeciesID

                };
                return result;
            }
            else
            {
                return null;
            }
        }

        public List<wsChickenLibrary> GetChickenLibraryBySpeciesID(string speciesID)
        {
            NanoFarmDataContext dc = new NanoFarmDataContext();
            List<wsChickenLibrary> result = new List<wsChickenLibrary>();

            var chickenModel = dc.Chicken_Libraries.Where(acSet => acSet.SpeciesID == speciesID);
            if (chickenModel != null)
            {
                foreach (Chicken_Library chicken in chickenModel)
                {
                    result.Add(new wsChickenLibrary()
                    {
                        TypeID = chicken.TypeID,
                        Name = chicken.Name,
                        Picture = chicken.Picture,
                        DayOld_Max = chicken.DayOld_Max.Value,
                        DayOld_Min = chicken.DayOld_Min.Value,
                        Food_Amount = chicken.Food_Amount.Value,
                        Food_Eat_No = chicken.Food_Eat_No.Value,
                        Humidity_Min = chicken.Humidity_Min.Value,
                        Humidity_Max = chicken.Humidity_Max.Value,

                        Lighting_Duration = chicken.Lighting_Duration,
                        Temperature_Min = chicken.Temperature_Min.Value,
                        Temperature_Max = chicken.Temperature_Max.Value,

                        Weight = chicken.Weight.Value,
                        SpeciesID = chicken.SpeciesID
                    });
                }
                return result;
            }
            else
            {
                return null;
            }
        }
        public string InsertChickenLibrary(string TypeId, string SpeciesID, string Name, string Picture, string DayOld_Min, string DayOld_Max, string Temperature_Min, 
                                            string Temperature_Max, string Humidity_Min, string Humidity_Max, string Lighting_Duration, string Food_Amount, string Food_Eat_No, string Weight)
        {
            try
            {
                Chicken_Library actionSetting = new Chicken_Library()
                {
                    TypeID = TypeId,
                    Name = Name,
                    Picture = Picture,
                    Weight = Convert.ToDouble(Weight),
                    Temperature_Min = Convert.ToInt32(Temperature_Min),
                    Temperature_Max = Convert.ToInt32(Temperature_Max),
                    Lighting_Duration = Lighting_Duration,
                    DayOld_Max = Convert.ToInt32(DayOld_Max), 
                    DayOld_Min = Convert.ToInt32(DayOld_Min),
                    Food_Amount = Convert.ToInt32(Food_Amount),
                    Food_Eat_No = Convert.ToInt32(Food_Eat_No),
                    Humidity_Min = Convert.ToInt32(Humidity_Min),
                    Humidity_Max = Convert.ToInt32(Humidity_Max),
                    SpeciesID = SpeciesID
                };

                using (var nano = new NanoFarmDataContext())
                {
                    nano.Chicken_Libraries.InsertOnSubmit(actionSetting);
                    nano.SubmitChanges();
                }
                return "Success";
            }
            catch (Exception ex)
            {
                return "Error: " + ex.Message;
            }
        }
        public string UpdateChickenLibrary(string TypeId, string SpeciesID, string Name, string Picture, string DayOld_Min, string DayOld_Max, string Temperature_Min,
                                            string Temperature_Max, string Humidity_Min, string Humidity_Max, string Lighting_Duration, string Food_Amount, string Food_Eat_No, string Weight)
        {
            try
            {
                using (var nano = new NanoFarmDataContext())
                {
                    var actionSetting = nano.Chicken_Libraries.Where(s => s.TypeID == TypeId).FirstOrDefault();

                    actionSetting.TypeID = TypeId;
                    actionSetting.Name = Name;
                    actionSetting.Picture = Picture;

                    actionSetting.TypeID = TypeId;
                    actionSetting.Name = Name;
                    actionSetting.Picture = Picture;
                    actionSetting.Weight = Convert.ToDouble(Weight);
                    actionSetting.Temperature_Min = Convert.ToInt32(Temperature_Min);
                    actionSetting.Temperature_Max = Convert.ToInt32(Temperature_Max);
                    actionSetting.Lighting_Duration = Lighting_Duration;
                    actionSetting.DayOld_Max = Convert.ToInt32(DayOld_Max); 
                    actionSetting.DayOld_Min = Convert.ToInt32(DayOld_Min);
                    actionSetting.Food_Amount = Convert.ToInt32(Food_Amount);
                    actionSetting.Food_Eat_No = Convert.ToInt32(Food_Eat_No);
                    actionSetting.Humidity_Min = Convert.ToInt32(Humidity_Min);
                    actionSetting.Humidity_Max = Convert.ToInt32(Humidity_Max);
                    actionSetting.SpeciesID = SpeciesID;
                }

                return "Success";
            }
            catch (Exception ex)
            {
                return "Error: " + ex.Message;
            }
        }

        public string DeleteChickenLibrary(string TypeID)
        {
            try
            {
                using (var nano = new NanoFarmDataContext())
                {
                    var actionSetting = nano.Chicken_Libraries.Where(s => s.TypeID == TypeID).FirstOrDefault();

                    nano.Chicken_Libraries.DeleteOnSubmit(actionSetting);
                    nano.SubmitChanges();
                }



                return "Success";
            }
            catch (Exception ex)
            {
                return "Error: " + ex.Message;
            }
        }


        #endregion

        #region Condition
        public List<wsCondition> GetAllCondition()
        {
            try
            {
                NanoFarmDataContext dc = new NanoFarmDataContext();
                List<wsCondition> result = new List<wsCondition>();
                foreach (Condition condition in dc.Conditions)
                {
                    result.Add(new wsCondition()
                    {
                        HubID = condition.HubID,
                        Temperature_Outside = condition.Temperature_Outside.Value,
                        Temperature_Inside = condition.Temperature_Inside.Value,
                        Temperature_Heater = condition.Temperature_Heater.Value,
                        Humidity_Outside = condition.Humidity_Outside.Value,
                        Humidity_Inside = condition.Humidity_Inside.Value,
                        Humidity_MistingStatus = condition.Humidity_MistingStatus.Value,
                        Light_Outside = condition.Light_Outside.Value,
                        Light_Inside = condition.Light_Inside.Value,
                        Light_Lamp_Status = condition.Light_Lamp_Status.Value


                    });
                }
                return result;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public wsCondition GetCondition(string HubID)
        {
            NanoFarmDataContext dc = new NanoFarmDataContext();
            var conditionModel = dc.Conditions.Where(acSet => acSet.HubID == HubID).FirstOrDefault();
            if (conditionModel != null)
            {
                wsCondition result = new wsCondition()
                {
                    HubID = conditionModel.HubID,
                    Temperature_Outside = conditionModel.Temperature_Outside.Value,
                    Temperature_Inside = conditionModel.Temperature_Inside.Value,
                    Temperature_Heater = conditionModel.Temperature_Heater.Value,
                    Humidity_Outside = conditionModel.Humidity_Outside.Value,
                    Humidity_Inside = conditionModel.Humidity_Inside.Value,
                    Humidity_MistingStatus = conditionModel.Humidity_MistingStatus.Value,
                    Light_Outside = conditionModel.Light_Outside.Value,
                    Light_Inside = conditionModel.Light_Inside.Value,
                    Light_Lamp_Status = conditionModel.Light_Lamp_Status.Value

                };
                return result;
            }
            else
            {
                return null;
            }
        }

        public string InsertCondition(string HubID, string TemperatureOutside, string TemperatureInside, string TemperatureHeater, string HumidityOutside, string HumidityInside, string HumidityMistingStatus, string LightOutside, string LightInside, string LightLampStatus)
        {
            try
            {
                Condition actionSetting = new Condition()
                {

                    HubID = HubID,
                    Temperature_Outside = Convert.ToInt32(TemperatureOutside),
                    Temperature_Heater = Convert.ToInt32(TemperatureHeater),
                    Temperature_Inside = Convert.ToInt32(TemperatureInside),
                    Humidity_Outside = Convert.ToInt32(HumidityOutside),
                    Humidity_Inside = Convert.ToInt32(HumidityInside),
                    Humidity_MistingStatus = Convert.ToBoolean(HumidityMistingStatus),
                    Light_Outside = Convert.ToInt32(LightOutside),
                    Light_Inside = Convert.ToInt32(LightInside),
                    Light_Lamp_Status = Convert.ToBoolean(LightLampStatus)
                };

                using (var nano = new NanoFarmDataContext())
                {
                    nano.Conditions.InsertOnSubmit(actionSetting);
                    nano.SubmitChanges();
                }
                return "Success";
            }
            catch (Exception ex)
            {
                return "Error: " + ex.Message;
            }
        }

        public string UpdateCondition(string HubID, string TemperatureOutside, string TemperatureInside, string TemperatureHeater, string HumidityOutside, string HumidityInside, string HumidityMistingStatus, string LightOutside, string LightInside, string LightLampStatus)
        {
            try
            {
                using (var nano = new NanoFarmDataContext())
                {
                    var actionSetting = nano.Conditions.Where(s => s.HubID == HubID).FirstOrDefault();

                    actionSetting.HubID = HubID;

                    actionSetting.Temperature_Outside = Convert.ToInt32(TemperatureOutside);
                    actionSetting.Temperature_Inside = Convert.ToInt32(TemperatureInside);
                    actionSetting.Temperature_Heater = Convert.ToInt32(TemperatureHeater);

                    actionSetting.Humidity_Outside = Convert.ToInt32(HumidityOutside);
                    actionSetting.Humidity_Inside = Convert.ToInt32(HumidityInside);
                    actionSetting.Humidity_MistingStatus = Convert.ToBoolean(HumidityMistingStatus);

                    actionSetting.Light_Outside = Convert.ToInt32(LightOutside);
                    actionSetting.Light_Inside = Convert.ToInt32(LightInside);
                    actionSetting.Light_Lamp_Status = Convert.ToBoolean(LightLampStatus);

                    nano.SubmitChanges();
                }



                return "Success";
            }
            catch (Exception ex)
            {
                return "Error: " + ex.Message;
            }
        }

        public string DeleteCondition(string HubID)
        {
            try
            {
                using (var nano = new NanoFarmDataContext())
                {
                    var actionSetting = nano.Conditions.Where(s => s.HubID == HubID).FirstOrDefault();

                    nano.Conditions.DeleteOnSubmit(actionSetting);
                    nano.SubmitChanges();
                }



                return "Success";
            }
            catch (Exception ex)
            {
                return "Error: " + ex.Message;
            }
        }



        #endregion

        #region CurrentCare
        public List<wsCurrentCare> GetAllCurrentCare()
        {
            try
            {
                NanoFarmDataContext dc = new NanoFarmDataContext();
                List<wsCurrentCare> result = new List<wsCurrentCare>();
                foreach (Current_Care condition in dc.Current_Cares)
                {
                    result.Add(new wsCurrentCare()
                    {
                        HubID = condition.HubID,
                        Name = condition.Name,
                        Picture = condition.Picture,
                        SpeciesID = condition.SpeciesID,

                        Humidity_Value = condition.Humidity_Value.Value,
                        Humidity_Min = condition.Humidity_Min.Value,
                        Humidity_Max = condition.Humidity_Max.Value,

                        Food_Eat_No = condition.Food_Eat_No.Value,
                        Food_Amount = condition.Food_Amount.Value,

                        Lighting_Duration = condition.Lighting_Duration,

                        Temperature_Value = condition.Temperature_Value.Value,
                        Temperature_Min = condition.Temperature_Min.Value,
                        Temperature_Max= condition.Temperature_Max.Value,

                        Weight = condition.Weight.Value

                    });
                }
                return result;
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        public wsCurrentCare GetCurrentCare(string HubID)
        {

            NanoFarmDataContext dc = new NanoFarmDataContext();
            var condition = dc.Current_Cares.Where(acSet => acSet.HubID == HubID).FirstOrDefault();
            if (condition != null)
            {
                wsCurrentCare result = new wsCurrentCare()
                {
                    HubID = condition.HubID,
                    Name = condition.Name,
                    Picture = condition.Picture,
                    SpeciesID = condition.SpeciesID,

                    Humidity_Value = condition.Humidity_Value.Value,
                    Humidity_Min = condition.Humidity_Min.Value,
                    Humidity_Max = condition.Humidity_Max.Value,

                    Food_Eat_No = condition.Food_Eat_No.Value,
                    Food_Amount = condition.Food_Amount.Value,

                    Lighting_Duration = condition.Lighting_Duration,

                    Temperature_Value = condition.Temperature_Value.Value,
                    Temperature_Min = condition.Temperature_Min.Value,
                    Temperature_Max = condition.Temperature_Max.Value,

                    Weight = condition.Weight.Value
                };
                return result;
            }
            else
            {
                return null;
            }
        }
        public string InsertCurrentCare(string HubID, string SpeciesID, string Name, string Picture, string Temperature_Value, string Temperature_Min, string Temperature_Max, string Humidity_Value,  string Humidity_Min, string Humidity_Max, string Lighting_Duration, string Food_Amount, string Food_Eat_No, string Weight)
        {
            try
            {
                Current_Care actionSetting = new Current_Care()
                {
                    HubID = HubID,
                    Name = Name,
                    Picture = Picture,
                    Weight = Convert.ToDouble(Weight),

                    Temperature_Value = Convert.ToInt32(Temperature_Value),
                    Temperature_Min = Convert.ToInt32(Temperature_Min),
                    Temperature_Max = Convert.ToInt32(Temperature_Max),

                    Lighting_Duration = Lighting_Duration,


                    Food_Amount = Convert.ToDouble(Food_Amount),
                    Food_Eat_No = Convert.ToInt32(Food_Eat_No),

                    Humidity_Value = Convert.ToInt32(Humidity_Value),
                    Humidity_Min = Convert.ToInt32(Humidity_Min),
                    Humidity_Max = Convert.ToInt32(Humidity_Max),

                    SpeciesID = SpeciesID

                };

                using (var nano = new NanoFarmDataContext())
                {
                    nano.Current_Cares.InsertOnSubmit(actionSetting);
                    nano.SubmitChanges();
                }
                return "Success";
            }
            catch (Exception ex)
            {
                return "Error: " + ex.Message;
            }
        }
        public string UpdateCurrentCare(string HubID, string SpeciesID, string Name, string Picture, string Temperature_Value, string Temperature_Min, string Temperature_Max, string Humidity_Value, string Humidity_Min, string Humidity_Max, string Lighting_Duration, string Food_Amount, string Food_Eat_No, string Weight)
        {
            try
            {
                using (var nano = new NanoFarmDataContext())
                {
                    var actionSetting = nano.Current_Cares.Where(s => s.HubID == HubID).FirstOrDefault();

                    actionSetting.HubID = HubID;
                    actionSetting.Name = Name;
                    actionSetting.Picture = Picture;
                    actionSetting.Weight = Convert.ToDouble(Weight);

                    actionSetting.Temperature_Value = Convert.ToInt32(Temperature_Value);
                    actionSetting.Temperature_Min = Convert.ToInt32(Temperature_Min);
                    actionSetting.Temperature_Max = Convert.ToInt32(Temperature_Max);

                    actionSetting.Humidity_Value = Convert.ToInt32(Humidity_Value);
                    actionSetting.Humidity_Min = Convert.ToInt32(Humidity_Min);
                    actionSetting.Humidity_Max = Convert.ToInt32(Humidity_Max);

                    actionSetting.Lighting_Duration = Lighting_Duration;
                    actionSetting.Food_Amount = Convert.ToDouble(Food_Amount);
                    actionSetting.Food_Eat_No = Convert.ToInt32(Food_Eat_No);
                    actionSetting.SpeciesID = SpeciesID;

                    nano.SubmitChanges();
                }



                return "Success";
            }
            catch (Exception ex)
            {
                return "Error: " + ex.Message;
            }
        }
        public string DeleteCurrentCare(string HubID)
        {
            try
            {
                using (var nano = new NanoFarmDataContext())
                {
                    var actionSetting = nano.Current_Cares.Where(s => s.HubID == HubID).FirstOrDefault();

                    nano.Current_Cares.DeleteOnSubmit(actionSetting);
                    nano.SubmitChanges();
                }



                return "Success";
            }
            catch (Exception ex)
            {
                return "Error: " + ex.Message;
            }
        }

        #endregion

        #region InoculationList
        public List<wsInoculationList> GetAllInoculationList()
        {
            try
            {
                NanoFarmDataContext dc = new NanoFarmDataContext();
                List<wsInoculationList> result = new List<wsInoculationList>();
                foreach (Inoculation_List condition in dc.Inoculation_Lists)
                {
                    result.Add(new wsInoculationList()
                    {
                        HubID = condition.HubId,
                        DaysOld = condition.DaysOld,
                        Medicine = condition.Medicine,
                        Method = condition.Method,
                        SpeciesID = condition.SpeciesID,
                        TypeID = condition.TypeID
                    });
                }
                return result;
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        public wsInoculationList GetInoculationList(string HubID, string DaysOld)
        {
            NanoFarmDataContext dc = new NanoFarmDataContext();
            var conditionModel = dc.Inoculation_Lists.Where(acSet => acSet.HubId == HubID && acSet.DaysOld == DaysOld).FirstOrDefault();
            if (conditionModel != null)
            {
                wsInoculationList result = new wsInoculationList()
                {
                   HubID = conditionModel.HubId,
                   DaysOld = conditionModel.DaysOld,
                   Medicine = conditionModel.Medicine,
                   Method = conditionModel.Method,
                   TypeID = conditionModel.TypeID
                };
                return result;
            }
            else
            {
                return null;
            }
        }
        public string InsertInoculationList(string HubID, string SpeciesID , string TypeID, string DaysOld, string Medicine, string Method)
        {
            try
            {
                Inoculation_List actionSetting = new Inoculation_List()
                {

                   HubId = HubID,
                   DaysOld = DaysOld,
                   Medicine = Medicine,
                   Method = Method,
                   SpeciesID = SpeciesID,
                   TypeID = TypeID
                };

                using (var nano = new NanoFarmDataContext())
                {
                    nano.Inoculation_Lists.InsertOnSubmit(actionSetting);
                    nano.SubmitChanges();
                }
                return "Success";
            }
            catch (Exception ex)
            {
                return "Error: " + ex.Message;
            }
        }
        public string UpdateInoculationList(string HubID, string SpeciesID, string TypeID, string DaysOld, string Medicine, string Method)
        {
            try
            {
                using (var nano = new NanoFarmDataContext())
                {
                    var actionSetting = nano.Inoculation_Lists.Where(s => s.HubId == HubID && s.DaysOld == DaysOld).FirstOrDefault();

                    actionSetting.HubId = HubID;
                    actionSetting.DaysOld = DaysOld;
                    actionSetting.Medicine = Medicine;
                    actionSetting.Method = Method;
                    actionSetting.SpeciesID= SpeciesID;
                    actionSetting.TypeID = TypeID;
                    nano.SubmitChanges();
                }


                return "Success";
            }
            catch (Exception ex)
            {
                return "Error: " + ex.Message;
            }
        }
        public string DeleteInoculationList(string HubID, string DaysOld)
        {
            try
            {
                using (var nano = new NanoFarmDataContext())
                {
                    var actionSetting = nano.Inoculation_Lists.Where(s => s.HubId == HubID && s.DaysOld == DaysOld).FirstOrDefault();
                    nano.Inoculation_Lists.DeleteOnSubmit(actionSetting);
                    nano.SubmitChanges();
                }

                return "Success";
            }
            catch (Exception ex)
            {
                return "Error: " + ex.Message;
            }
        }
        #endregion

        //#region LibInoculationList
        //public List<wsLibInoculationList> GetAllLibInoculationList()
        //{
        //    try
        //    {
        //        NanoFarmDataContext dc = new NanoFarmDataContext();
        //        List<wsLibInoculationList> result = new List<wsLibInoculationList>();
        //        foreach (Lib_Inoculation_List condition in dc.Lib_Inoculation_Lists)
        //        {
        //            result.Add(new wsLibInoculationList()
        //            {
        //                TypeID = condition.TypeID,
        //                Time = condition.Time,
        //                Medicine = condition.Medicine,
        //                Method = condition.Method
        //            });
        //        }
        //        return result;
        //    }
        //    catch (Exception ex)
        //    {
        //        return null;
        //    }
        //}

        //public wsLibInoculationList GetLibInoculationList(string TypeID, string Time)
        //{
        //    NanoFarmDataContext dc = new NanoFarmDataContext();
        //    var conditionModel = dc.Lib_Inoculation_Lists.Where(acSet => acSet.TypeID == TypeID && acSet.Time == Time).FirstOrDefault();
        //    if (conditionModel != null)
        //    {
        //        wsLibInoculationList result = new wsLibInoculationList()
        //        {
        //            TypeID = conditionModel.TypeID,
        //            Time = conditionModel.Time,
        //            Medicine = conditionModel.Medicine,
        //            Method = conditionModel.Method
        //        };
        //        return result;
        //    }
        //    else
        //    {
        //        return null;
        //    }
        //}

        //public string InsertLibInoculationList(string TypeID, string Time, string Medicine, string Method)
        //{
        //    try
        //    {
        //        Lib_Inoculation_List actionSetting = new Lib_Inoculation_List()
        //        {

        //            TypeID = TypeID,
        //            Time = Time,
        //            Medicine = Medicine,
        //            Method = Method



        //        };

        //        using (var nano = new NanoFarmDataContext())
        //        {
        //            nano.Lib_Inoculation_Lists.InsertOnSubmit(actionSetting);
        //            nano.SubmitChanges();
        //        }
        //        return "Success";
        //    }
        //    catch (Exception ex)
        //    {
        //        return "Error: " + ex.Message;
        //    }
        //}

        //public string UpdateLibInoculationList(string TypeID, string Time, string Medicine, string Method)
        //{
        //    try
        //    {
        //        using (var nano = new NanoFarmDataContext())
        //        {
        //            var actionSetting = nano.Lib_Inoculation_Lists.Where(s => s.TypeID == TypeID && s.Time == Time).FirstOrDefault();

        //            actionSetting.TypeID = TypeID;
        //            actionSetting.Time = Time;
        //            actionSetting.Medicine = Medicine;
        //            actionSetting.Method = Method;





        //            nano.SubmitChanges();
        //        }



        //        return "Success";
        //    }
        //    catch (Exception ex)
        //    {
        //        return "Error: " + ex.Message;
        //    }
        //}

        //public string DeleteLibInoculationList(string TypeID, string Time)
        //{
        //    try
        //    {
        //        using (var nano = new NanoFarmDataContext())
        //        {
        //            var actionSetting = nano.Lib_Inoculation_Lists.Where(s => s.TypeID == TypeID && s.Time == Time).FirstOrDefault();

        //            nano.Lib_Inoculation_Lists.DeleteOnSubmit(actionSetting);
        //            nano.SubmitChanges();
        //        }



        //        return "Success";
        //    }
        //    catch (Exception ex)
        //    {
        //        return "Error: " + ex.Message;
        //    }
        //}


        //#endregion

        #region Logs
        public List<wsLogs> GetAllLogs()
        {
            try
            {
                NanoFarmDataContext dc = new NanoFarmDataContext();
                List<wsLogs> result = new List<wsLogs>();
                foreach (Log condition in dc.Logs)
                {
                    result.Add(new wsLogs()
                    {

                       HubID = condition.HubID,
                       Time = condition.Time,
                       Action = condition.Time,
                       Account = condition.Account


                    });
                }
                return result;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public wsLogs GetLog(string HubID, string Time)
        {
            NanoFarmDataContext dc = new NanoFarmDataContext();
            var conditionModel = dc.Logs.Where(acSet => acSet.HubID == HubID && acSet.Time == Time).FirstOrDefault();
            if (conditionModel != null)
            {
                wsLogs result = new wsLogs()
                {
                    HubID = conditionModel.HubID,
                    Time = conditionModel.Time,
                    Action = conditionModel.Action,
                    Account = conditionModel.Account
                };
                return result;
            }
            else
            {
                return null;
            }
        }

        public string InsertLog(string HubID, string Time, string Action, string Account)
        {
            try
            {
                Log actionSetting = new Log()
                {

                    HubID = HubID,
                    Time = Time,
                    Account = Account,
                    Action = Action



                };

                using (var nano = new NanoFarmDataContext())
                {
                    nano.Logs.InsertOnSubmit(actionSetting);
                    nano.SubmitChanges();
                }
                return "Success";
            }
            catch (Exception ex)
            {
                return "Error: " + ex.Message;
            }
        }

        public string UpdateLog(string HubID, string Time, string Action, string Account)
        {
            try
            {
                using (var nano = new NanoFarmDataContext())
                {
                    var actionSetting = nano.Logs.Where(s => s.HubID == HubID && s.Time == Time).FirstOrDefault();

                    actionSetting.HubID = HubID;
                    actionSetting.Time = Time;
                    actionSetting.Action = Action;
                    actionSetting.Account = Account;





                    nano.SubmitChanges();
                }



                return "Success";
            }
            catch (Exception ex)
            {
                return "Error: " + ex.Message;
            }
        }

        public string DeleteLog(string HubID, string Time)
        {
            try
            {
                using (var nano = new NanoFarmDataContext())
                {
                    var actionSetting = nano.Logs.Where(s => s.HubID == HubID && s.Time == Time).FirstOrDefault();

                    nano.Logs.DeleteOnSubmit(actionSetting);
                    nano.SubmitChanges();
                }



                return "Success";
            }
            catch (Exception ex)
            {
                return "Error: " + ex.Message;
            }
        }

        #endregion

        #region Notifications
        public List<wsNotifications> GetAllNotifications()
        {
            try
            {
                NanoFarmDataContext dc = new NanoFarmDataContext();
                List<wsNotifications> result = new List<wsNotifications>();
                foreach (Notification condition in dc.Notifications)
                {
                    result.Add(new wsNotifications()
                    {
                        HubId = condition.HubId,
                        ID = condition.ID,
                        Noti_Action = condition.Noti_Action.Value,
                        Noti_Code = condition.Noti_Code.Value,
                        Noti_Read = condition.Noti_Read.Value,
                        Date_Time = condition.Date_Time
                    });
                }
                return result;
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        public List<wsNotifications> GetNotificationByHubID(string HubID)
        {
            NanoFarmDataContext dc = new NanoFarmDataContext();
            List<wsNotifications> lstNoti = new List<wsNotifications>();

            var notiModel = dc.Notifications.Where(acSet => acSet.HubId == HubID);
            if (notiModel != null)
            {
                foreach(var item in notiModel)
                {
                    wsNotifications result = new wsNotifications()
                    {
                        HubId = item.HubId,
                        Noti_Read = item.Noti_Read.Value,
                        Noti_Code = item.Noti_Code.Value,
                        Noti_Action = item.Noti_Action.Value,
                        ID = item.ID,
                        Date_Time = item.Date_Time
                    };

                    lstNoti.Add(result);
                }
                return lstNoti;
            }
            else
            {
                return null;
            }
        }
        public string InsertNotification(string ID, string HubId, string Noti_Code, string Noti_Action, string Noti_Read, string Date_Time  )
        {
            try
            {
                Notification actionSetting = new Notification()
                {

                    ID  = Convert.ToInt32(ID),
                    HubId = HubId,
                    Noti_Read = Convert.ToBoolean(Noti_Read),
                    Noti_Code = Convert.ToInt32(Noti_Code),
                    Noti_Action = Convert.ToBoolean(Noti_Action),
                    Date_Time = Date_Time
                };

                using (var nano = new NanoFarmDataContext())
                {
                    nano.Notifications.InsertOnSubmit(actionSetting);
                    nano.SubmitChanges();
                }
                return "Success";
            }
            catch (Exception ex)
            {
                return "Error: " + ex.Message;
            }
        }
        public string UpdateNotification(string ID, string HubId, string Noti_Code, string Noti_Action, string Noti_Read, string Date_Time)
        {
            try
            {
                using (var nano = new NanoFarmDataContext())
                {
                    var actionSetting = nano.Notifications.Where(s => s.ID == Convert.ToInt32(ID)).FirstOrDefault();

                    actionSetting.ID = Convert.ToInt32(ID);
                    actionSetting.HubId = HubId;
                    actionSetting.Noti_Read = Convert.ToBoolean(Noti_Read);
                    actionSetting.Noti_Code = Convert.ToInt32(Noti_Code);
                    actionSetting.Noti_Action = Convert.ToBoolean(Noti_Action);
                    actionSetting.Date_Time = Date_Time;

                    nano.SubmitChanges();
                }



                return "Success";
            }
            catch (Exception ex)
            {
                return "Error: " + ex.Message;
            }
        }
        public string DeleteNotification(string ID)
        {
            try
            {
                using (var nano = new NanoFarmDataContext())
                {
                    var actionSetting = nano.Notifications.Where(s => s.ID ==  Convert.ToInt32(ID)).FirstOrDefault();

                    nano.Notifications.DeleteOnSubmit(actionSetting);
                    nano.SubmitChanges();
                }
                return "Success";
            }
            catch (Exception ex)
            {
                return "Error: " + ex.Message;
            }
        }

        public string DeleteAllNotification(string hubID)
        {
            try
            {
                using (var nano = new NanoFarmDataContext())
                {
                    var actionSetting = nano.Notifications.Where(s => s.HubId == hubID).FirstOrDefault();
                    nano.Notifications.DeleteOnSubmit(actionSetting);
                    nano.SubmitChanges();
                }
                return "Success";
            }
            catch (Exception ex)
            {
                return "Error: " + ex.Message;
            }
        }

        #endregion

        #region NotificationContents
        public List<wsNotificationContents> GetAllNotificationContents()
        {
            try
            {
                NanoFarmDataContext dc = new NanoFarmDataContext();
                List<wsNotificationContents> result = new List<wsNotificationContents>();
                foreach (var condition in dc.Notification_Contents)
                {
                    result.Add(new wsNotificationContents()
                    {
                        Noti_Content = condition.Noti_Content,
                        Noti_Code = condition.Noti_Code,
                    });
                }
                return result;
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        public wsNotificationContents GetNotificationContentId(string notiCode)
        {
            NanoFarmDataContext dc = new NanoFarmDataContext();
           var lstNoti = new wsNotificationContents();

            var notiModel = dc.Notification_Contents.Where(acSet => acSet.Noti_Code == Convert.ToInt32(notiCode)).FirstOrDefault();

            if (notiModel != null)
            {
                var notiContentData = new wsNotificationContents()
                {
                    Noti_Code = notiModel.Noti_Code,
                    Noti_Content = notiModel.Noti_Content
                };

                return notiContentData;
            }
            else
            {
                return null;
            }
        }
        #endregion
    }   
}
