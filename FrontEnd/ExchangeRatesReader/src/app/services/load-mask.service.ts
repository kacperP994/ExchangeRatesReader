import { Injectable } from '@angular/core';
import { BehaviorSubject } from 'rxjs';

@Injectable({
  providedIn: 'root'
})

  /**
	 * A service showing loading spinner, used during api calls. The mask is hidden when every api call is finished
	 */
export class LoadMaskService {

  private isLoading: any = new BehaviorSubject(false);

  private cnt = 0;

  public loading = this.isLoading.asObservable();

  /**
	 * Pokazuje maskę
	 */
	public show() {
		this.cnt++;
		this.isLoading.next(true);
	}

	/**
	 * Chowa maskę
	 */
	public hide() {
		this.cnt--;
		if (this.cnt <= 0) {
			this.cnt = 0;
			this.isLoading.next(false);
		}
	}

  constructor() { }
}
