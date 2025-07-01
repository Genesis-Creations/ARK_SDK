using System;

namespace ARK.SDK.Models.Content
{
    public class AddCourseResponse
    {
        public string id { get; set; }
        public string description { get; set; }
        public string displayName { get; set; }
     //   public DateTime expireDate { get; set; }
        public string image { get; set; }
        public bool isDemo { get; set; }
      //  public bool isSuspended { get; set; }
        public string[] labels { get; set; }
      //  public int licenseCount { get; set; }
      //  public int modulesCount { get; set; }
        public string name { get; set; }
     //   public int sessionsCount { get; set; }
    }
}