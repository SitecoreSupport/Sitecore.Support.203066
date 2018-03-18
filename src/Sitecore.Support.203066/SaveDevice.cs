using Sitecore.Analytics.DataAccess.Dictionaries;
using Sitecore.Diagnostics;
using Sitecore.Analytics.Pipelines.SubmitSessionContext;

namespace Sitecore.Support.Analytics.Pipelines.SubmitSessionContext
{
  internal class SaveDevice : SubmitSessionContextProcessor
  {
    public override void Process(SubmitSessionContextArgs args)
    {
      Assert.ArgumentNotNull(args, "args");
      bool flag = args.Session.Device != null;
      if (flag)
      {
        var deviceFromxConnect =
          KnownDataDictionaries.Devices.Get(args.Session.Device.DeviceId, LookupStrategy.BypassCache);

        if (deviceFromxConnect != null &&
            deviceFromxConnect.LastKnownContactId == args.Session.Device.LastKnownContactId)
        {
          //device is already saved from another session.
          return;
        }

        KnownDataDictionaries.Devices.Put(args.Session.Device);
      }
    }
  }
}
