using Sitecore;
using Sitecore.Configuration;
using Sitecore.Data;
using Sitecore.Data.Fields;
using Sitecore.Data.Items;
using Sitecore.XA.Foundation.Multisite.LinkManagers;

namespace MadCill.XA.Feature.MediaExtensions.Media.Services
{
    public class MediaItemService : Sitecore.XA.Feature.Media.Services.MediaItemService
    {
        public MediaItemService(Sitecore.Abstractions.BaseMediaManager mediaManager) 
            : base(mediaManager)
        {
        }

        public override string GetImageFieldTargetUrl(Item item, ID fieldId)
        {
            string str = string.Empty;
            ImageField field = (ImageField)item.Fields[fieldId];
            if (field?.MediaItem != null)
            {
                str = this.MediaManager.GetMediaUrl(new MediaItem(field.MediaItem));
                if (!Settings.GetBoolSetting("Media.AlwaysIncludeServerUrl", false))
                {
                    str = StringUtil.EnsurePrefix('/', str);
                }                
            }
            return str;
        }
    }
}
