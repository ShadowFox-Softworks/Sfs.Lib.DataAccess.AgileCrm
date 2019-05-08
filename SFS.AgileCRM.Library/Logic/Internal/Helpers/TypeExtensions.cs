namespace SFS.AgileCRM.Library.Logic.Internal.Helpers
{
    using SFS.AgileCRM.Library.Data.Static;
    using SFS.AgileCRM.Library.Data.Static.Internal;

    /// <summary>
    /// The Type Extensions.
    /// </summary>
    internal static class TypeExtensions
    {
        /// <summary>
        /// Returns the field value in AddressType where the field name matches the AgileCrmAddressType enum.
        /// </summary>
        /// <param name="addressType">Type of the phsyical address.</param>
        /// <returns>
        ///   <see cref="string" />.
        /// </returns>
        public static string ToAddressTypeValue(this AgileCrmAddressType addressType)
        {
            return typeof(AddressType).GetField(addressType.ToString()).GetValue(null).ToString();
        }

        /// <summary>
        /// Returns the field value in EmailType where the field name matches the AgileCrmEmailType enum.
        /// </summary>
        /// <param name="emailType">Type of the email address.</param>
        /// <returns>
        ///   <see cref="string" />.
        /// </returns>
        public static string ToEmailTypeValue(this AgileCrmEmailType emailType)
        {
            return typeof(EmailType).GetField(emailType.ToString()).GetValue(null).ToString();
        }

        /// <summary>
        /// Returns the field value in PhoneType where the field name matches the AgileCrmPhoneType enum.
        /// </summary>
        /// <param name="phoneType">Type of the phone number.</param>
        /// <returns>
        ///   <see cref="string" />.
        /// </returns>
        public static string ToPhoneTypeValue(this AgileCrmPhoneType phoneType)
        {
            return typeof(PhoneType).GetField(phoneType.ToString()).GetValue(null).ToString();
        }

        /// <summary>
        /// Returns the field value in TaskPriorityType where the field name matches the AgileCrmTaskPriorityType enum.
        /// </summary>
        /// <param name="taskPriorityType">Type of the task priority.</param>
        /// <returns>
        ///   <see cref="string" />.
        /// </returns>
        public static string ToTaskPriorityTypeValue(this AgileCrmTaskPriorityType taskPriorityType)
        {
            return typeof(TaskPriorityType).GetField(taskPriorityType.ToString()).GetValue(null).ToString();
        }

        /// <summary>
        /// Returns the field value in TaskStatusType where the field name matches the AgileCrmTaskStatusType enum.
        /// </summary>
        /// <param name="taskStatusType">Type of the task status.</param>
        /// <returns>
        ///   <see cref="string" />.
        /// </returns>
        public static string ToTaskStatusTypeValue(this AgileCrmTaskStatusType taskStatusType)
        {
            return typeof(TaskStatusType).GetField(taskStatusType.ToString()).GetValue(null).ToString();
        }

        /// <summary>
        /// Returns the field value in TaskType where the field name matches the AgileCrmTaskType enum.
        /// </summary>
        /// <param name="taskType">Type of the task.</param>
        /// <returns>
        ///   <see cref="string"/>.
        /// </returns>
        public static string ToTaskTypeValue(this AgileCrmTaskType taskType)
        {
            return typeof(TaskType).GetField(taskType.ToString()).GetValue(null).ToString();
        }

        /// <summary>
        /// Returns the field value in WebsiteType where the field name matches the AgileCrmWebsiteType enum.
        /// </summary>
        /// <param name="websiteType">Type of the website.</param>
        /// <returns>
        ///   <see cref="string" />.
        /// </returns>
        public static string ToWebsiteTypeValue(this AgileCrmWebsiteType websiteType)
        {
            return typeof(WebsiteType).GetField(websiteType.ToString()).GetValue(null).ToString();
        }
    }
}