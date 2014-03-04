namespace com.smartsheet.api.models
{
	/*
	 * #[license]
	 * Smartsheet SDK for C#
	 * %%
	 * Copyright (C) 2014 Smartsheet
	 * %%
	 * Licensed under the Apache License, Version 2.0 (the "License");
	 * you may not use this file except in compliance with the License.
	 * You may obtain a copy of the License at
	 * 
	 *      http://www.apache.org/licenses/LICENSE-2.0
	 * 
	 * Unless required by applicable law or agreed to in writing, software
	 * distributed under the License is distributed on an "AS IS" BASIS,
	 * WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
	 * See the License for the specific language governing permissions and
	 * limitations under the License.
	 * %[license]
	 */



	/// <summary>
	/// Represents an object with an ID.
	/// </summary>
	public abstract class IdentifiableModel
	{
		/// <summary>
		/// Represents the ID. </summary>
		private long? id_Renamed;

		/// <summary>
		/// Gets the id.
		/// </summary>
		/// <returns> the id </returns>
		public virtual long? id
		{
			get
			{
				return id_Renamed;
			}
			set
			{
				this.id_Renamed = value;
			}
		}


		/// <summary>
		/// Check if the given object equals to this object.
		/// </summary>
		/// <param name="object"> the object to compare </param>
		/// <returns> true if given object equals to this object, false otherwise </returns>
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
		/// Return the hash code of this object.
		/// </summary>
		/// <returns> the hash code </returns>
        public override int GetHashCode()
		{
			int result = 17;
			if (this.id_Renamed == null)
			{
                result = base.GetHashCode();
			}
			else
			{
				result = 31 * result + (int)((long)this.id_Renamed ^ ((int)((long)(uint)this.id_Renamed >> 32)));
			}

			return result;
		}
	}

}