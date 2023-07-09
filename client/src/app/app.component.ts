import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.scss']
})
export class AppComponent implements OnInit {
  title = 'meow';

  constructor()
  {
  }
  ngOnInit(): void {
    
  }
  //ctor for dependency injectoin, ngoninit to get data on initialize, not ctor
  //subscribe if observable is returned

}
