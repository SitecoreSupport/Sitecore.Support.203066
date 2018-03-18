using Sitecore.Analytics.DataAccess.Dictionaries;
using Sitecore.Diagnostics;
using System;

namespace Sitecore.Analytics.Pipelines.SubmitSessionContext
{
  internal class SaveDevice : SubmitSessionContextProcessor
  {
    public override void Process(SubmitSessionContextArgs args)
    {
      Assert.ArgumentNotNull(args, "args");
      bool flag = args.Session.Device != null;
      if (flag)
      {
        KnownDataDictionaries.Devices.Put(args.Session.Device);
      }
    }
  }
}
