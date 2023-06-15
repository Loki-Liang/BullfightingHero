using System;
using System.Collections.Generic;

namespace NetworkUtils
{
    [Serializable]
    public class UserInfo
    {
        /**
		* 用户ID
	 */
        private long userId;

        /**
	 * 部门ID
	 */
        private long deptId;

        /**
	 * 用户账号
	 */
        private String userName;

        /**
	 * 用户昵称
	 */
        private String nickName;

        /**
	 * 用户邮箱
	 */
        private String email;

        /**
	 * 手机号码
	 */
        private String phonenumber;

        /**
	 * 用户性别
	 */
        private String sex;

        /**
	 * 用户头像
	 */
        private String avatar;

        /**
	 * 密码
	 */
        private String password;


        public String getPassword()
        {
            return password;
        }

        /**
	 * 帐号状态（0正常 1停用）
	 */
        private String status;

        /**
	 * 删除标志（0代表存在 1代表删除）
	 */
        private int delFlag;

        /**
	 * 最后登录IP
	 */
        private String loginIp;

        /**
	 * 最后登录时间
	 */
        private DateTime loginDate;

        /**
	 * 备注
	 */
        private String remark;

        //       /**
        // * 部门对象
        // */
        //       private SysDept dept;
        //
        //       /**
        // * 角色对象
        // */
        //       private List<SysRole> roles;

        /**
	 * 角色组
	 */
        private long[] roleIds;

        /**
	 * 岗位组
	 */
        private long[] postIds;

        /**
	 * 角色ID
	 */
        private long roleId;

        // public SysUser(long userId)
        // {
        //     this.userId = userId;
        // }

        /// <summary>
        /// 是否是管理员
        /// </summary>
        /// <returns></returns>
        public bool isAdmin()
        {
            return isAdmin(this.userId);
        }

        public static bool isAdmin(long? userId)
        {
            return userId != null && 1L == userId;
        }
    }
}