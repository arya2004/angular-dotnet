import { Injectable } from '@angular/core';
import { NgxSpinnerService } from 'ngx-spinner';

@Injectable({
  providedIn: 'root'
})
export class BusyService {
    busyRequestCount = 0;
  constructor(private spinnerServ :  NgxSpinnerService) { }

  busy()
  {
    this.busyRequestCount++;
    this.spinnerServ.show(undefined, {
      type: 'timer',
      bdColor: 'rgba(255,255,255,0.8)',
      color: '#333333'
    })
  }
  idle()
  {
    this.busyRequestCount--;
    if(this.busyRequestCount <= 0){
      this.busyRequestCount = 0;
      this.spinnerServ.hide();
    }
  }
}
