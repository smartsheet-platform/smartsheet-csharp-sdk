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
		/// 
		/// Exceptions: - IllegalArgumentException : if any argument is null
		/// </summary>
		/// <param name="smartsheet"> the Smartsheet </param>
		public DiscussionCommentResourcesImpl(SmartsheetImpl smartsheet)
			: base(smartsheet)
		{ }
	}
}
