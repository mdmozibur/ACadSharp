﻿using CSUtilities.Extensions;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace ACadSharp
{
	/// <summary>
	/// Collection formed by <see cref="CadObject"/> managed by an owner.
	/// </summary>
	/// <typeparam name="T"></typeparam>
	public class CadObjectCollection<T> : IObservableCadCollection<T>
		where T : CadObject
	{
		/// <inheritdoc/>
		public event EventHandler<CollectionChangedEventArgs> OnAdd;

		/// <inheritdoc/>
		public event EventHandler<CollectionChangedEventArgs> OnRemove;

		/// <summary>
		/// Owner of the collection.
		/// </summary>
		public CadObject Owner { get; }

		/// <summary>
		/// Gets the number of elements that are contained in the collection.
		/// </summary>
		public int Count { get { return this._entries.Count; } }

		protected readonly HashSet<T> _entries = new HashSet<T>();

		/// <summary>
		/// Default constructor for a <see cref="CadObjectCollection{T}"/> with it's owner assigned.
		/// </summary>
		/// <param name="owner">Owner of the collection.</param>
		public CadObjectCollection(CadObject owner)
		{
			this.Owner = owner;
		}

		public bool Contains(T elem)
		{
			return _entries.Contains(elem);
		}

		/// <summary>
		/// Add a <see cref="CadObject"/> to the collection, this method triggers <see cref="OnAdd"/>.
		/// </summary>
		/// <param name="item"></param>
		/// <exception cref="ArgumentException"></exception>
		/// <exception cref="ArgumentNullException"></exception>
		public virtual void Add(T item)
		{
			if (item is null) throw new ArgumentNullException(nameof(item));

			if (item.Owner != null)
				throw new ArgumentException($"Item {item.GetType().FullName} already has an owner", nameof(item));

			if (this._entries.Contains(item))
				throw new ArgumentException($"Item {item.GetType().FullName} is already in the collection", nameof(item));

			this._entries.Add(item);
			item.Owner = this.Owner;

			OnAdd?.Invoke(this, new CollectionChangedEventArgs(item));
		}

		/// <summary>
		/// Add multiple <see cref="CadObject"/> to the collection, this method triggers <see cref="OnAdd"/>.
		/// </summary>
		/// <param name="items"></param>
		public void AddRange(IEnumerable<T> items)
		{
			foreach (var item in items)
			{
				this.Add(item);
			}
		}

		/// <summary>
		/// Removes all elements from the Collection.
		/// </summary>
		public void Clear()
		{
			this._entries.Clear();
		}

		/// <summary>
		/// Removes a <see cref="CadObject"/> from the collection, this method triggers <see cref="OnRemove"/>.
		/// </summary>
		/// <param name="item"></param>
		/// <returns>The removed <see cref="CadObject"/></returns>
		public virtual T Remove(T item)
		{
			if (!this._entries.Remove(item))
				return null;

			item.Owner = null;

			OnRemove?.Invoke(this, new CollectionChangedEventArgs(item));

			return item;
		}

		/// <inheritdoc/>
		public IEnumerator<T> GetEnumerator()
		{
			return this._entries.GetEnumerator();
		}

		/// <inheritdoc/>
		IEnumerator IEnumerable.GetEnumerator()
		{
			return this._entries.GetEnumerator();
		}
	}
}
