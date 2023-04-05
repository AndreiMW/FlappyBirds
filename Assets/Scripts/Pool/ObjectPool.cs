/**
 * Created Date: 4/5/2023
 * Author: Andrei-Florin Ciobanu
 * 
 * Copyright (c) 2023 Avangarde Software. All rights reserved. 
 */

using System.Collections.Generic;

using UnityEngine;

namespace Pool {
	public abstract class ObjectPool<T> : MonoBehaviour {
    	[SerializeField] 
    	private int _initialPoolSize = 10;
    
    	private Queue<T> _pool;
    	
    	#region Lifecycle
    
    	private void Awake() {
    		this._pool = new Queue<T>();
    		this.Allocate(this._initialPoolSize);
    	}
    	
    	#endregion
    	
    	#region Protected
    
    	protected abstract T CreatePooled();
    	protected virtual void OnGet(T pooled) {}
    	protected virtual void OnReturn(T pooled) {}
    	
    	#endregion
    	
    	#region Public
    
    	/// <summary>
    	/// Get an item from the pool
    	/// </summary>
    	/// <returns>The pooled item.</returns>
    	public T Get() {
    		T item = this._pool.Dequeue();
    		this.OnGet(item);
    		return item;
    	}
    
    	/// <summary>
    	/// Return item into the pool.
    	/// </summary>
    	/// <param name="item">The item to return to the pool.</param>
    	public void Return(T item) {
    		this.OnReturn(item);
    		this._pool.Enqueue(item);
    	}
    	
    	#endregion
    	
    	#region Private
    	
    	private void Allocate(int amount) {
    		for (var i = 0; i < amount; i++) {
    			this._pool.Enqueue(CreatePooled());
    		}
    	}
    	
    	#endregion
    }
}
