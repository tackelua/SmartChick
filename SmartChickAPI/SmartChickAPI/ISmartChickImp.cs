using SmartChickAPI.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace SmartChickAPI
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "ISmartChickImp" in both code and config file together.
    [ServiceContract]
    public interface ISmartChickImp
    {

        #region Demo

        [OperationContract]
        [WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Wrapped, UriTemplate = "Demo/{id}")]
        string Demo(string Id);

        #endregion

        #region User
        /// <summary>
        /// Get All User
        /// </summary>
        /// <returns>List of users</returns>
        [OperationContract]
        [WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Wrapped, UriTemplate = "getAllUsers")]
        List<wsUser> GetAllUsers();

        /// <summary>
        /// Get User by Email
        /// </summary>
        /// <param name="Email">Email of user</param>
        /// <returns></returns>
        [OperationContract]
        [WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Wrapped, UriTemplate = "getUser/{Email}")]
        wsUser GetUser(string Email);

        /// <summary>
        /// Get User by Email
        /// </summary>
        /// <param name="Email">Email of user</param>
        /// <returns></returns>
        [OperationContract]
        [WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Wrapped, UriTemplate = "insertUser/{email}_{name}_{sexual}_{yearOld}_{picture}_{password}")]
        string InsertUser(string email,string name,string sexual,string yearOld,string picture, string password);

        /// <summary>
        /// Update User
        /// </summary>
        /// <param name="email"></param>
        /// <param name="name"></param>
        /// <param name="sexual"></param>
        /// <param name="yearOld"></param>
        /// <param name="picture"></param>
        /// <returns></returns>
        [OperationContract]
        [WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Wrapped, UriTemplate = "updateUser/{email}_{name}_{sexual}_{yearOld}_{picture}_{password}")]
        string UpdateUser(string email, string name, string sexual, string yearOld, string picture, string password);


        [OperationContract]
        [WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Wrapped, UriTemplate = "deleteUser/{email}")]
        string DeleteUser(string email);
        #endregion

        #region Hub Information
        /// <summary>
        /// Get All Hub Information
        /// </summary>
        /// <returns>List of hub information</returns>
        [OperationContract]
        [WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Wrapped, UriTemplate = "getAllHub")]
        List<wsHubInformation> GetAllHubInformation();

        /// <summary>
        /// Get hub
        /// </summary>
        /// <param name="ID">Hub ID</param>
        /// <returns></returns>
        [OperationContract]
        [WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Wrapped, UriTemplate = "getHub/{ID}")]
        wsHubInformation GetHub(string ID);

        /// <summary>
        /// Insert Hub
        /// </summary>
        /// <param name="id"></param>
        /// <param name="name"></param>
        /// <param name="password"></param>
        /// <param name="location"></param>
        /// <param name="email"></param>
        /// <returns></returns>
        [OperationContract]
        [WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Wrapped, UriTemplate = "insertHub/{id}_{name}_{location}_{email}")]
        string InsertHub(string id,string name,string location,string email);

        /// <summary>
        /// Update Hub
        /// </summary>
        /// <param name="id"></param>
        /// <param name="name"></param>
        /// <param name="password"></param>
        /// <param name="location"></param>
        /// <param name="email"></param>
        /// <returns></returns>
        [OperationContract]
        [WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Wrapped, UriTemplate = "updateHub/{id}_{name}_{location}_{email}")]
        string UpdateHub(string id, string name, string location, string email);

        [OperationContract]
        [WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Wrapped, UriTemplate = "deleteHub/{id}")]
        string DeleteHub(string id);
        #endregion

        #region Action
        [OperationContract]
        [WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Wrapped, UriTemplate = "getAllActions")]
        List<wsAction> GetAllActions();

        [OperationContract]
        [WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Wrapped, UriTemplate = "getAction/{HubID}")]
        wsAction GetAction(string HubID);

        [OperationContract]
        [WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Wrapped, UriTemplate = "insertAction/{HubID}_{Feed_Status}_{Active_Status}_{Active_Speed}_{Gate_Status}_{Clean_Status}_{Sterilise_Status}_{Light_Status}")]
        string InsertAction(string HubID, string Feed_Status, string Active_Status, string Active_Speed, string Gate_Status, string Clean_Status, string Sterilise_Status, string Light_Status);

        [OperationContract]
        [WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Wrapped, UriTemplate = "updateAction/{HubID}_{Feed_Status}_{Active_Status}_{Active_Speed}_{Gate_Status}_{Clean_Status}_{Sterilise_Status}_{Light_Status}")]
        string UpdateAction(string HubID, string Feed_Status, string Active_Status, string Active_Speed, string Gate_Status, string Clean_Status, string Sterilise_Status, string Light_Status);

        [OperationContract]
        [WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Wrapped, UriTemplate = "deleteAction/{HubID}")]
        string DeleteAction(string HubID);


        #endregion

        #region Action Setting

        [OperationContract]
        [WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Wrapped, UriTemplate = "getAllActionSettings")]
        List<wsActionSetting> GetAllActionSetting();

        [OperationContract]
        [WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Wrapped, UriTemplate = "getActionSetting/{HubID}")]
        wsActionSetting GetActionSettings(string HubID);

        [OperationContract]
        [WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Wrapped, 
            UriTemplate = "insertActionSetting/{hubID}_{Feed_Moment}_{Feed_Mode}_{Active_Moment}_{Active_Speed}_{Active_Time}_{Active_Mode}_{Open_Gate}_{Close_Gate}_{Gate_Mode}_{Clean_Moment}_{Clean_Mode}_{Sterilise_Moment_Day}_{Sterilise_Moment_Time}_{Sterilise_Mode}_{Light_Mode}_{Light_On_Time}_{Light_Off_time}")]
        string InsertActionSetting(string hubID, string Feed_Moment, string Feed_Mode, string Active_Moment, string Active_Speed, string Active_Time, string Active_Mode, string Open_Gate, string Close_Gate, string Gate_Mode, string Clean_Moment, string Clean_Mode, string Sterilise_Moment_Day, string Sterilise_Moment_Time, string Sterilise_Mode, string Light_Mode, string Light_On_Time, string Light_Off_time);
        [OperationContract]
        [WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Wrapped, UriTemplate = "updateActionSetting/{hubID}_{Feed_Moment}_{Feed_Mode}_{Active_Moment}_{Active_Speed}_{Active_Time}_{Active_Mode}_{Open_Gate}_{Close_Gate}_{Gate_Mode}_{Clean_Moment}_{Clean_Mode}_{Sterilise_Moment_Day}_{Sterilise_Moment_Time}_{Sterilise_Mode}_{Light_Mode}_{Light_On_Time}_{Light_Off_time}")]
        string UpdateActionSetting(string hubID, string Feed_Moment, string Feed_Mode, string Active_Moment, string Active_Speed, string Active_Time, string Active_Mode, string Open_Gate, string Close_Gate, string Gate_Mode, string Clean_Moment, string Clean_Mode, string Sterilise_Moment_Day, string Sterilise_Moment_Time, string Sterilise_Mode, string Light_Mode, string Light_On_Time, string Light_Off_time);

        [OperationContract]
        [WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Wrapped, UriTemplate = "deleteActionSetting/{HubID}")]
        string DeleteActionSetting(string HubID);
        #endregion

        #region Chicken
        [OperationContract]
        [WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Wrapped, UriTemplate = "getAllChicken")]
        List<wsChicken> GetAllChicken();

        [OperationContract]
        [WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Wrapped, UriTemplate = "getChicken/{HubID}")]
        wsChicken GetChicken(string HubID);

        [OperationContract]
        [WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Wrapped, UriTemplate = "insertChicken/{HubID}_{spiecesID}_{Name}_{DayOld}_{Quantity}_{Outside}_{Inside}_{Weight}_{BodyTemp}")]
        string InsertChicken(string HubID, string spiecesID, string name, string dayold, string quantity, string outside, string inside, string weight, string bodytemp);

        [OperationContract]
        [WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Wrapped, UriTemplate = "updateChicken/{HubID}_{spiecesID}_{Name}_{DayOld}_{Quantity}_{Outside}_{Inside}_{Weight}_{BodyTemp}")]
        string UpdateChicken(string HubID, string spiecesID, string name, string dayold, string quantity, string outside, string inside,  string weight, string bodytemp);

        [OperationContract]
        [WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Wrapped, UriTemplate = "deleteChicken/{HubID}")]
        string DeleteChicken(string HubID);
        #endregion

        #region Chicken List
        [OperationContract]
        [WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Wrapped, UriTemplate = "getAllChickenList")]
        List<wsChickenList> GetAllChickenList();

        [OperationContract]
        [WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Wrapped, UriTemplate = "getChickenList/{SpeciesID}")]
        wsChickenList GetChickenList(string SpeciesID);

        [OperationContract]
        [WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Wrapped, UriTemplate = "insertChickenList/{SpecicesID}_{Name}_{Picture}")]
        string InsertChickenList(string SpecicesID, string Name, string Picture);

        [OperationContract]
        [WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Wrapped, UriTemplate = "updateChickenList/{SpecicesID}_{Name}_{Picture}")]
        string UpdateChickenList(string SpecicesID, string Name, string Picture);

        [OperationContract]
        [WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Wrapped, UriTemplate = "deleteChickenList/{SpecicesID}")]
        string DeleteChickenList(string SpecicesID);
        #endregion

        #region ChickenLibrary

        [OperationContract]
        [WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Wrapped, UriTemplate = "getAllChickenLibrary")]
        List<wsChickenLibrary> GetAllChickenLibrary();

        [OperationContract]
        [WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Wrapped, UriTemplate = "getChickenLibrary/{TypeID}")]
        wsChickenLibrary GetChickenLibrary(string TypeID);

        [OperationContract]
        [WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Wrapped, UriTemplate = "getChickenLibraryBySID/{speciesID}")]
        List<wsChickenLibrary> GetChickenLibraryBySpeciesID(string speciesID);

        [OperationContract]
        [WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Wrapped,
            UriTemplate = "insertChickenLibrary/{TypeId}_{SpeciesID}_{Name}_{Picture}_{DayOld_Min}_{DayOld_Max}_"
            + "{Temperature_Min}_{Temperature_Max}_{Humidity_Min}_{Humidity_Max}_{Lighting_Duration}_{Food_Amount}_{Food_Eat_No}_{Weight}")]

        string InsertChickenLibrary(string TypeId, string SpeciesID, string Name, string Picture, string DayOld_Min, string DayOld_Max, string Temperature_Min,
                                            string Temperature_Max, string Humidity_Min, string Humidity_Max, string Lighting_Duration, string Food_Amount, string Food_Eat_No, string Weight);

        [OperationContract]
        [WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Wrapped,
            UriTemplate = "updateChickenLibrary/{TypeId}_{SpeciesID}_{Name}_{Picture}_{DayOld_Min}_{DayOld_Max}_"
            + "{Temperature_Min}_{Temperature_Max}_{Humidity_Min}_{Humidity_Max}_{Lighting_Duration}_{Food_Amount}_{Food_Eat_No}_{Weight}")]

        string UpdateChickenLibrary(string TypeId, string SpeciesID, string Name, string Picture, string DayOld_Min, string DayOld_Max, string Temperature_Min,
                                            string Temperature_Max, string Humidity_Min, string Humidity_Max, string Lighting_Duration, string Food_Amount, string Food_Eat_No, string Weight);

        [OperationContract]
        [WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Wrapped, UriTemplate = "deleteChickenLibrary/{TypeID}")]
        string DeleteChickenLibrary(string TypeID);
        #endregion

        #region Condition

        [OperationContract]
        [WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Wrapped, UriTemplate = "getAllCondition")]
        List<wsCondition> GetAllCondition();

        [OperationContract]
        [WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Wrapped, UriTemplate = "getCondition/{HubID}")]
        wsCondition GetCondition(string HubID);

        [OperationContract]
        [WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Wrapped, UriTemplate = "insertCondition/{HubID}_{TemperatureOutside}_{TemperatureInside}_{TemperatureHeater}_{HumidityOutside}_{HumidityInside}_{HumidityMistingStatus}_{LightOutside}_{LightInside}_{LightLampStatus}")]
        string InsertCondition(string HubID,string TemperatureOutside,string TemperatureInside,string TemperatureHeater,string HumidityOutside,string HumidityInside,string HumidityMistingStatus,string LightOutside,string LightInside,string LightLampStatus);


        [OperationContract]
        [WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Wrapped, UriTemplate = "updateCondition/{HubID}_{TemperatureOutside}_{TemperatureInside}_{TemperatureHeater}_{HumidityOutside}_{HumidityInside}_{HumidityMistingStatus}_{LightOutside}_{LightInside}_{LightLampStatus}")]
        string UpdateCondition(string HubID, string TemperatureOutside, string TemperatureInside, string TemperatureHeater, string HumidityOutside, string HumidityInside, string HumidityMistingStatus, string LightOutside, string LightInside, string LightLampStatus);

        [OperationContract]
        [WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Wrapped, UriTemplate = "deleteCondition/{HubID}")]
        string DeleteCondition(string HubID);
        #endregion

        #region CurrentCare

        [OperationContract]
        [WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Wrapped, UriTemplate = "getAllCurrentCare")]
        List<wsCurrentCare> GetAllCurrentCare();

        [OperationContract]
        [WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Wrapped, UriTemplate = "getCurrentCare/{HubID}")]
        wsCurrentCare GetCurrentCare(string HubID);

        [OperationContract]
        [WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Wrapped,
                                    UriTemplate = "insertCurrentCare/{HubID}_{SpeciesID}_{Name}_{Picture}_{Temperature_Value}_{Temperature_Min}_{Temperature_Max}_{Humidity_Value}_{Humidity_Min}_{Humidity_Max}_{Lighting_Duration}_"
                                                + "{Food_Amount}_{Food_Eat_No}_{Weight}")]
        string InsertCurrentCare(string HubID, string SpeciesID, string Name, string Picture, string Temperature_Value, string Temperature_Min, string Temperature_Max, string Humidity_Value, string Humidity_Min, string Humidity_Max, string Lighting_Duration, string Food_Amount, string Food_Eat_No, string Weight);

        [OperationContract]
        [WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Wrapped, UriTemplate = "updateCurrentCare/{HubID}_{SpeciesID}_{Name}_{Picture}_{Temperature_Value}_{Temperature_Min}_{Temperature_Max}_{Humidity_Value}_{Humidity_Min}_{Humidity_Max}_{Lighting_Duration}_"
                                                + "{Food_Amount}_{Food_Eat_No}_{Weight}")]
        string UpdateCurrentCare(string HubID, string SpeciesID, string Name, string Picture, string Temperature_Value, string Temperature_Min, string Temperature_Max, string Humidity_Value, string Humidity_Min, string Humidity_Max, string Lighting_Duration, string Food_Amount, string Food_Eat_No, string Weight);
        [OperationContract]
        [WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Wrapped, UriTemplate = "deleteCurrentCare/{HubID}")]
        string DeleteCurrentCare(string HubID);
        #endregion

        #region InoculationList

        [OperationContract]
        [WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Wrapped, UriTemplate = "getAllInoculationList")]
        List<wsInoculationList> GetAllInoculationList();

        [OperationContract]
        [WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Wrapped, UriTemplate = "getInoculationList/{HubID}_{Time}")]
        wsInoculationList GetInoculationList(string HubID,string Time);

        [OperationContract]
        [WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Wrapped, UriTemplate = "insertInoculationList/{HubID}_{SpeciesID}_{TypeID}_{DaysOld}_{Medicine}_{Method}")]
        string InsertInoculationList(string HubID, string SpeciesID, string TypeID, string DaysOld, string Medicine, string Method);


        [OperationContract]
        [WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Wrapped, UriTemplate = "updateInoculationList/{HubID}_{SpeciesID}_{TypeID}_{DaysOld}_{Medicine}_{Method}")]
        string UpdateInoculationList(string HubID, string SpeciesID, string TypeID, string DaysOld, string Medicine, string Method);

        [OperationContract]
        [WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Wrapped, UriTemplate = "deleteInoculationList/{HubID}_{Time}")]
        string DeleteInoculationList(string HubID,string Time);
        #endregion

        //#region LibInoculationList

        //[OperationContract]
        //[WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Wrapped, UriTemplate = "getAllLibInoculationList")]
        //List<wsLibInoculationList> GetAllLibInoculationList();

        //[OperationContract]
        //[WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Wrapped, UriTemplate = "getLibInoculationList/{TypeID}_{Time}")]
        //wsLibInoculationList GetLibInoculationList(string TypeID, string Time);

        //[OperationContract]
        //[WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Wrapped, UriTemplate = "insertLibInoculationList/{TypeID}_{Time}_{Medicine}_{Method}")]
        //string InsertLibInoculationList(string TypeID, string Time, string Medicine, string Method);


        //[OperationContract]
        //[WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Wrapped, UriTemplate = "updateLibInoculationList/{TypeID}_{Time}_{Medicine}_{Method}")]
        //string UpdateLibInoculationList(string TypeID, string Time, string Medicine, string Method);

        //[OperationContract]
        //[WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Wrapped, UriTemplate = "deleteLibInoculationList/{TypeID}_{Time}")]
        //string DeleteLibInoculationList(string TypeID, string Time);
        //#endregion

        #region Logs

        [OperationContract]
        [WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Wrapped, UriTemplate = "getAllLogs")]
        List<wsLogs> GetAllLogs();

        [OperationContract]
        [WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Wrapped, UriTemplate = "getLog/{HubID}_{Time}")]
        wsLogs GetLog(string HubID, string Time);

        [OperationContract]
        [WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Wrapped, UriTemplate = "insertLog/{HubID}_{Time}_{Action}_{Account}")]
        string InsertLog(string HubID, string Time, string Action, string Account);


        [OperationContract]
        [WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Wrapped, UriTemplate = "updateLog/{HubID}_{Time}_{Action}_{Account}")]
        string UpdateLog(string HubID, string Time, string Action, string Account);

        [OperationContract]
        [WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Wrapped, UriTemplate = "deleteLog/{HubID}_{Time}")]
        string DeleteLog(string HubID, string Time);
        #endregion

        #region Notifications

        [OperationContract]
        [WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Wrapped, UriTemplate = "getAllNotifications")]
        List<wsNotifications> GetAllNotifications();

        [OperationContract]
        [WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Wrapped, UriTemplate = "getNotification/{HubID}")]
        List<wsNotifications> GetNotificationByHubID(string HubID);

        [OperationContract]
        [WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Json,
            BodyStyle = WebMessageBodyStyle.Wrapped, UriTemplate = "insertNotification/{ID}_{HubId}_{Noti_Code}_{Noti_Action}_{Noti_Read}_{Date_Time}")]
        string InsertNotification(string ID, string HubId, string Noti_Code, string Noti_Action, string Noti_Read, string Date_Time);

        [OperationContract]
        [WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Json, 
            BodyStyle = WebMessageBodyStyle.Wrapped, UriTemplate = "updateNotification/{ID}_{HubId}_{Noti_Code}_{Noti_Action}_{Noti_Read}_{Date_Time}")]
        string UpdateNotification(string ID, string HubId, string Noti_Code, string Noti_Action, string Noti_Read, string Date_Time);

        [OperationContract]
        [WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Wrapped, UriTemplate = "deleteNotification/{ID}")]
        string DeleteNotification(string ID);

        [OperationContract]
        [WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Wrapped, UriTemplate = "deleteAllNotification/{hubId}")]
        string DeleteAllNotification(string hubId);
        #endregion

        #region NotificationContent

        [OperationContract]
        [WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Wrapped, UriTemplate = "getAllNotificationContents")]
        List<wsNotificationContents> GetAllNotificationContents();

        [OperationContract]
        [WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Wrapped, UriTemplate = "getNotificationContent/{notiCode}")]
        wsNotificationContents GetNotificationContentId(string notiCode);

        #endregion
    }
}
