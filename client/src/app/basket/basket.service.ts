import { Injectable } from '@angular/core';
import { BehaviorSubject } from 'rxjs';
import { environment } from 'src/environments/environment.development';
import { Basket, IBasket, IBasketItem, IBasketTotals } from '../shared/models/IBasket';
import { HttpClient } from '@angular/common/http';
import { IProduct } from '../shared/models/IProduct';
import { IType } from '../shared/models/IType';

@Injectable({
  providedIn: 'root'
})
export class BasketService {

  baseUrl = environment.apiUrl;
  private basketSource = new BehaviorSubject<IBasket | null>(null); //null is initial value. createss an observable
  basketSource$ = this.basketSource.asObservable();
  private basketTotalSource = new BehaviorSubject<IBasketTotals | null >(null);
  basketTotalSource$ = this.basketTotalSource.asObservable();
  constructor(private http: HttpClient) { }

  getBasket(id: string)
  {
    return this.http.get<IBasket>(this.baseUrl + 'basket?id=' + id).subscribe({
      next: basket => {
        this.basketSource.next(basket);
        this.calculateTotal();
      }
    })
  }
  setBasket(basket: IBasket)
  {
    return this.http.post<IBasket>(this.baseUrl + 'basket', basket).subscribe({
      next: basket => {
        this.basketSource.next(basket);
        this.calculateTotal();
      }
    })
  }
  getCurrentBasketVAlue()
  {
    return this.basketSource.value;
  }

  addItemToBasket(item: IProduct | IBasketItem, quantity = 1)
  { 
    
    if (this.isProduct(item)) item = this.mapProductItemToBasktItem(item);
    const basket = this.getCurrentBasketVAlue() ?? this.createBasket();
    basket.items = this.addOrUpdateItem(basket.items, item, quantity)
    this.setBasket(basket)
  }

  removeItemFromBasket(id: number, quantity = 1)
  {
    const basket = this.getCurrentBasketVAlue();
    if(!basket) return;

    const item = basket.items.find(x => x.id === id)
    if(item)
    {
      item.quantity -= quantity;
      if(item.quantity === 0)
      {
        basket.items = basket.items.filter(x => x.id !== id)
      }
      if(basket.items.length > 0) this.setBasket(basket)
      else this.deleteBasket(basket);
    }

  }
  deleteBasket(basket: IBasket) {
    return this.http.delete(this.baseUrl + 'basket?id=' + basket.id).subscribe({
      next: () => {
        this.basketSource.next(null)
        this.basketTotalSource.next(null)
        localStorage.removeItem('basket_id')
      }
    })
  }

  private addOrUpdateItem(items: IBasketItem[], itemToAdd: IBasketItem, quantity: number): IBasketItem[] {
    const item = items.find(x => x.id === itemToAdd.id);
    if(item) item.quantity += quantity;
    else{
      itemToAdd.quantity = quantity;
      items.push(itemToAdd);
    }
    return items;
  }

  private createBasket(): IBasket  {
    const basket = new Basket();
    localStorage.setItem('basket_id', basket.id)
    return basket;
  }

  private mapProductItemToBasktItem(item: IProduct): IBasketItem{
    return {
      id: item.productId,
      productName: item.name,
      price: item.price,
      quantity: 0,
      pictureUrl: item.pictureUrl,
      brand: item.productBrand,
      type: item.productType
    }
  }

  private calculateTotal()
  {
    const basket = this.getCurrentBasketVAlue();
    if(!basket) return;
    const shipping = 0;
    const subtotal = basket.items.reduce((a, b) => (b.price * b.quantity) + a, 0)
    const total = subtotal + shipping;
    this.basketTotalSource.next({shipping, total, subtotal})
  }

  private isProduct(item: IProduct | IBasketItem): item is IProduct
  {
    return (item as IProduct).productBrand !== undefined;
  }
}
