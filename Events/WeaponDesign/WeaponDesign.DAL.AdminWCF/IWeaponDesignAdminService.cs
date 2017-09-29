using CommonLibs.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using WeaponDesign.Database.Database;

namespace WeaponDesign.DAL.AdminWCF
{
    // 注意: 使用“重构”菜单上的“重命名”命令，可以同时更改代码和配置文件中的接口名“IService1”。
    [ServiceContract]
    public interface IWeaponDesignAdminService
    {
        [OperationContract]
        WeaponList GetWeaponList(WeaponList searchWeaponList);
        [OperationContract]
        List<WeaponUserList> GetWeaponAllUserList(ref DataPage dp, WeaponUserList weaponuserlist);

        [OperationContract]
        Int32 UpdateWeaponStatus(WeaponList weaponList);

        [OperationContract]
        Int32 AddPraiseLog(PraiseLog praiseLog);

        [OperationContract]
        List<PraiseLog> GetPraiseLogList(ref DataPage dp, PraiseLog searchPraiseLog);
        [OperationContract]
        List<CommentsList> GetCommentsListList(ref DataPage dp, CommentsList searchCommentsList);
        [OperationContract]
        Int32 DelComment(Int32 iD);
        [OperationContract]
        Int32 UpdatePraiseNumber(PraiseNumber praiseNumber);
        [OperationContract]
        List<PraiseNumber> GetPraiseNumberList(ref DataPage dp);
        [OperationContract]
        Int32 PraiseScheduleAdd(PraiseSchedule searchPraiseSchedule);

        [OperationContract]
        bool PraiseScheduleDel(PraiseSchedule searchPraiseSchedule);

        [OperationContract]
        PraiseSchedule PraiseScheduleGetByID(PraiseSchedule searchPraiseSchedule);

        [OperationContract]
        List<PraiseSchedule> PraiseScheduleGetList(ref DataPage dp);

        [OperationContract]
        Int32 PraiseScheduleUpdate(PraiseSchedule searchPraiseSchedule);
    }

}
