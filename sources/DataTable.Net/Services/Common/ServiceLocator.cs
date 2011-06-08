using System;
using System.Collections.Generic;

namespace DataTable.Net.Services.Common
{
	public class ServiceLocator
	{
		#region Fields

		private readonly Dictionary<Type, object> services = new Dictionary<Type, object>();

		#endregion Fields

		#region Methods

		public void RegisterService<T>(T serviceImpl) where T: class
		{
			var serviceType = typeof(T);
			services[serviceType] = serviceImpl;
		}

		public T Resolve<T>() where T: class
		{
			var serviceType = typeof(T);
			if (!services.ContainsKey(serviceType))
			{
				return null;
			}

			return (T)services[serviceType];
		}

		#endregion Methods
	}
}