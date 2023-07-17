import { Component, OnInit } from '@angular/core';
import { BasketService } from './basket/basket.service';
import { AccountService } from './account/account.service';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.scss']
})
export class AppComponent implements OnInit {
  title = 'meow';

  constructor(private basketService: BasketService, private accountService: AccountService)
  {
  }
  ngOnInit(): void {
    this.loadBasket();
    this.loadCurrentUSer();
  }

  loadBasket()
  {
    const basketId = localStorage.getItem('basket_id');
    if(basketId) this.basketService.getBasket(basketId)
  
  }

  loadCurrentUSer()
  {
    const token = localStorage.getItem('token')
    
    if(token) this.accountService.loadCurrentUSer(token).subscribe();
  }
  //ctor for dependency injectoin, ngoninit to get data on initialize, not ctor
  //subscribe if observable is returned

}
