using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Linq;

namespace Filaaide.Core.Utilities
{
	public class ObservableDictionary<TKey, TValue> : IDictionary<TKey, TValue>, INotifyCollectionChanged, INotifyPropertyChanged
	{
		private const string COUNT_STRING = "Count";
		private const string INDEXER_NAME = "Item[]";
		private const string KEYS_NAME = "Keys";
		private const string VALUES_NAME = "Values";

		private IDictionary<TKey, TValue> _dictionary;

		protected IDictionary<TKey, TValue> Dictionary
		{
			get { return this._dictionary; }
		}

		public ObservableDictionary()
		{
			this._dictionary = new Dictionary<TKey, TValue>();
		}

		public ObservableDictionary(IDictionary<TKey, TValue> dictionary)
		{
			this._dictionary = new Dictionary<TKey, TValue>(dictionary);
		}

		public ObservableDictionary(IEqualityComparer<TKey> comparer)
		{
			this._dictionary = new Dictionary<TKey, TValue>(comparer);
		}

		public ObservableDictionary(int capacity)
		{
			this._dictionary = new Dictionary<TKey, TValue>(capacity);
		}

		public ObservableDictionary(IDictionary<TKey, TValue> dictionary, IEqualityComparer<TKey> comparer)
		{
			this._dictionary = new Dictionary<TKey, TValue>(dictionary, comparer);
		}

		public ObservableDictionary(int capacity, IEqualityComparer<TKey> comparer)
		{
			this._dictionary = new Dictionary<TKey, TValue>(capacity, comparer);
		}

		#region IDictionary<TKey,TValue> Members

		public void Add(TKey key, TValue value)
		{
			this.Insert(key, value, true);
		}

		public bool ContainsKey(TKey key)
		{
			return this.Dictionary.ContainsKey(key);
		}

		public ICollection<TKey> Keys
		{
			get { return this.Dictionary.Keys; }
		}

		public bool Remove(TKey key)
		{
			if (key == null) {
				throw new ArgumentNullException(nameof(key));
			}

			TValue value;
			this.Dictionary.TryGetValue(key, out value);
			var removed = this.Dictionary.Remove(key);
			if (removed) {
				this.OnCollectionChanged(NotifyCollectionChangedAction.Remove, new KeyValuePair<TKey, TValue>(key, value));
			}
			return removed;
		}

		public bool TryGetValue(TKey key, out TValue value)
		{
			return this.Dictionary.TryGetValue(key, out value);
		}

		public ICollection<TValue> Values
		{
			get { return this.Dictionary.Values; }
		}

		public TValue this[TKey key]
		{
			get {
				return this.Dictionary.ContainsKey(key) ? this.Dictionary[key] : default(TValue);
			}
			set {
				this.Insert(key, value, false);
			}
		}

		#endregion IDictionary<TKey,TValue> Members

		public void Add(KeyValuePair<TKey, TValue> item)
		{
			this.Insert(item.Key, item.Value, true);
		}

		public void Clear()
		{
			if (this.Dictionary.Count > 0) {
				this.Dictionary.Clear();
				this.OnCollectionChanged();
			}
		}

		public bool Contains(KeyValuePair<TKey, TValue> item)
		{
			return this.Dictionary.Contains(item);
		}

		public void CopyTo(KeyValuePair<TKey, TValue>[] array, int arrayIndex)
		{
			this.Dictionary.CopyTo(array, arrayIndex);
		}

		public int Count
		{
			get { return this.Dictionary.Count; }
		}

		public bool IsReadOnly
		{
			get { return this.Dictionary.IsReadOnly; }
		}

		public bool Remove(KeyValuePair<TKey, TValue> item)
		{
			return this.Remove(item.Key);
		}

		public IEnumerator<KeyValuePair<TKey, TValue>> GetEnumerator()
		{
			return this.Dictionary.GetEnumerator();
		}

		IEnumerator IEnumerable.GetEnumerator()
		{
			return ((IEnumerable) this.Dictionary).GetEnumerator();
		}

		public event NotifyCollectionChangedEventHandler CollectionChanged;

		public event PropertyChangedEventHandler PropertyChanged;

		public void AddRange(IDictionary<TKey, TValue> items)
		{
			if (items == null) {
				throw new ArgumentNullException(nameof(items));
			}

			if (items.Count > 0) {
				if (this.Dictionary.Count > 0) {

					if (items.Keys.Any((k) => this.Dictionary.ContainsKey(k))) {
						throw new ArgumentException("An item with the same key has already been added.");
					}

					foreach (var item in items) {
						this.Dictionary.Add(item);
					}

				} else {
					this._dictionary = new Dictionary<TKey, TValue>(items);
				}
				this.OnCollectionChanged(NotifyCollectionChangedAction.Add, items.ToArray());
			}
		}

		private void Insert(TKey key, TValue value, bool add)
		{
			if (key == null) {
				throw new ArgumentNullException(nameof(key));
			}

			TValue item;
			if (this.Dictionary.TryGetValue(key, out item)) {

				if (add) {
					throw new ArgumentException("An item with the same key has already been added.");
				}

				if (Equals(item, value)) {
					return;
				}

				this.Dictionary[key] = value;
				this.OnCollectionChanged(NotifyCollectionChangedAction.Replace, new KeyValuePair<TKey, TValue>(key, value), new KeyValuePair<TKey, TValue>(key, item));

			} else {
				this.Dictionary[key] = value;
				this.OnCollectionChanged(NotifyCollectionChangedAction.Add, new KeyValuePair<TKey, TValue>(key, value));
			}
		}

		private void OnPropertyChanged()
		{
			this.OnPropertyChanged(COUNT_STRING);
			this.OnPropertyChanged(INDEXER_NAME);
			this.OnPropertyChanged(KEYS_NAME);
			this.OnPropertyChanged(VALUES_NAME);
		}

		protected virtual void OnPropertyChanged(string propertyName)
		{
			this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
		}

		private void OnCollectionChanged()
		{
			this.OnPropertyChanged();
			this.CollectionChanged?.Invoke(this, new NotifyCollectionChangedEventArgs(NotifyCollectionChangedAction.Reset));
		}

		private void OnCollectionChanged(NotifyCollectionChangedAction action, KeyValuePair<TKey, TValue> changedItem)
		{
			this.OnPropertyChanged();
			this.CollectionChanged?.Invoke(this, new NotifyCollectionChangedEventArgs(action, changedItem));
		}

		private void OnCollectionChanged(NotifyCollectionChangedAction action, KeyValuePair<TKey, TValue> newItem, KeyValuePair<TKey, TValue> oldItem)
		{
			this.OnPropertyChanged();
			this.CollectionChanged?.Invoke(this, new NotifyCollectionChangedEventArgs(action, newItem, oldItem));
		}

		private void OnCollectionChanged(NotifyCollectionChangedAction action, IList newItems)
		{
			this.OnPropertyChanged();
			this.CollectionChanged?.Invoke(this, new NotifyCollectionChangedEventArgs(action, newItems));
		}
	}
}