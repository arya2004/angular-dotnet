import { HttpClient } from '@angular/common/http';
import { Component } from '@angular/core';
import { environment } from 'src/environments/environment.development';

@Component({
  selector: 'app-test-error',
  templateUrl: './test-error.component.html',
  styleUrls: ['./test-error.component.scss']
})
export class TestErrorComponent {
    baseUrl = environment.apiUrl;
  validationErrors:string[] = [];
    constructor(private http: HttpClient){}

    get404()
    {
      this.http.get(this.baseUrl + 'products/42').subscribe({
        next: res => console.log(res),
        error: err => console.log(err)
      })
    }

    get500()
    {
      this.http.get(this.baseUrl + 'buggy/servererror').subscribe({
        next: res => console.log(res),
        error: err => console.log(err)
      })
    }

    get400()
    {
      this.http.get(this.baseUrl + 'buggy/badrequest').subscribe({
        next: res => console.log(res),
        error: err => console.log(err)
      })
    }

    get400Val()
    {
      this.http.get(this.baseUrl + 'products/fourtytwo').subscribe({
        next: res => console.log(res),
        error: err => {
          console.log(err)
          this.validationErrors = err.errors
        }
      })
    }
}
