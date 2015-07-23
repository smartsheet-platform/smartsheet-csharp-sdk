//    #[license]
//    SmartsheetClient SDK for C#
//    %%
//    Copyright (C) 2014 SmartsheetClient
//    %%
//    Licensed under the Apache License, Version 2.0 (the "License");
//    you may not use this file except in compliance with the License.
//    You may obtain a copy of the License at
//        
//            http://www.apache.org/licenses/LICENSE-2.0
//        
//    Unless required by applicable law or agreed To in writing, software
//    distributed under the License is distributed on an "AS IS" BASIS,
//    WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
//    See the License for the specific language governing permissions and
//    limitations under the License.
//    %[license]

namespace Smartsheet.Api.Models
{

	/// <summary>
	/// Represents an object with an ID.
	/// </summary>
	public abstract class IdentifiableModel
	{
		/// <summary>
		/// Represents the ID. </summary>
		private long? id;

		/// <summary>
		/// Gets the Id.
		/// </summary>
		/// <returns> the Id </returns>
		public virtual long? Id
		{
			get
			{
				return id;
			}
			set
			{
				this.id = value;
			}
		}


		/// <summary>
		/// Check if the given object equals To this object.
		/// </summary>
		/// <param name="object"> the object To compare </param>
		/// <returns> true if given object equals To this object, false otherwise </returns>
		public override bool Equals(object @object)
		{
			bool result = false;

			if (@object != null && @object == this)
			{
				result = true;
			}
			else if (@object != null && @object.GetType() == this.GetType() && (((IdentifiableModel)@object).id == this.id || ((IdentifiableModel)@object).id != null && this.id != null && ((IdentifiableModel)@object).id.Equals(this.id)))
					// If they are both null
					// If they are not null but are equal objects.
			{
				result = true;
			}

			return result;
		}

		/// <summary>
		/// Return the hash Code of this object.
		/// </summary>
		/// <returns> the hash Code </returns>
		  public override int GetHashCode()
		{
			int result = 17;
			if (this.id == null)
			{
					result = base.GetHashCode();
			}
			else
			{
				result = 31 * result + (int)((long)this.id ^ ((int)((long)(uint)this.id >> 32)));
			}

			return result;
		}
	}

}