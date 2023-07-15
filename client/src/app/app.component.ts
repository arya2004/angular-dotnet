import { Component, OnInit } from '@angular/core';
import { BasketService } from './basket/basket.service';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.scss']
})
export class AppComponent implements OnInit {
  title = 'meow';

  constructor(private basketService: BasketService)
  {
  }
  ngOnInit(): void {
    const basketId = localStorage.getItem('basket_id');
    if(basketId) this.basketService.getBasket(basketId)
  }
  //ctor for dependency injectoin, ngoninit to get data on initialize, not ctor
  //subscribe if observable is returned

}
