namespace BlazorTaskManager.Helpers
{
    public class StringHelper
    {
        public static string ShortenString(string targetString, string typeOfString, int cutOffAmount)
        {
            if (targetString != null)
            {
                if (targetString.Length > cutOffAmount)
                {
                    targetString = targetString.Substring(0, cutOffAmount - 3) + "...";
                }

                return targetString;
            }
            else
            {
                return string.Concat("No ", typeOfString);
            }
        }
    }
}
