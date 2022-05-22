public class genlist<T> {

	public T[] data;
	public int size = 0, capacity = 2;
	public genlist() {data = new T[capacity]; }
	public void push(T item) {
		if(size==capacity) {
			T[] newdata = new T[capacity *= 2];
			for(int i = 0; i < size; i++)newdata[i]=data[i];
			data = newdata;		
		}
		data[size]=item; 
		size++;
	}
	public void remove(int i) {
		if(size == capacity/2 && size > 1)capacity /= 2;
		if(i >= size || i < 0) {throw new System.IndexOutOfRangeException($"index {i} not included in a list of size {size}");}
		else {
		int j = 0;
		T[] newdata = new T[capacity];
		for(int k = 0; k < size; k++) {
			if(k==i){continue;}
			else{newdata[j]=data[k]; j++;}
		}			
		data = newdata;
		size--;
		}
	}
	
}