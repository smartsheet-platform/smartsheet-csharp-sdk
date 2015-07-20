using Smartsheet.Api.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Smartsheet.Api.Internal
{
	public class DiscussionCommentResourcesImpl : AbstractResources, DiscussionCommentResources
	{
		/// <summary>
		/// Constructor.
		/// </summary>
		/// <param name="smartsheet"> the Smartsheet </param>
		/// <exception cref="IllegalArgumentException">if any argument is null</exception>
		public DiscussionCommentResourcesImpl(SmartsheetImpl smartsheet)
			: base(smartsheet)
		{

		}
	}
}
