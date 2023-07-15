import { Component, OnInit } from '@angular/core';
import { IProduct } from 'src/app/shared/models/IProduct';
import { ShopService } from '../shop.service';
import { ActivatedRoute } from '@angular/router';
import { BreadcrumbService } from 'xng-breadcrumb';
import { BasketService } from 'src/app/basket/basket.service';
import { take } from 'rxjs';

@Component({
  selector: 'app-product-details',
  templateUrl: './product-details.component.html',
  styleUrls: ['./product-details.component.scss']
})
export class ProductDetailsComponent implements OnInit {
  
  product?: IProduct;
  quantity = 1;
  quantityInBasket = 0;
  constructor(private shopService: ShopService, private activatedRoot: ActivatedRoute, private bcService: BreadcrumbService, private basketService: BasketService){}
  
  ngOnInit(): void {
    this.loadProduct();
  }

  loadProduct()
  {
    const id =  this.activatedRoot.snapshot.paramMap.get('id')//+ for subscrivbe
    
    if(id)  this.shopService.getProduct(+id).subscribe({
      next: prod => {
        this.product = prod;
        this.bcService.set('@productDetails', prod.name)
        this.basketService.basketSource$.pipe(take(1)).subscribe({
          next: basket =>{
            const item = basket?.items.find(x => x.id === +id);
            if(item){
              this.quantity = item.quantity;
              this.quantityInBasket = item.quantity
            }
          }
        })
      },
      error: err => console.log(err)
    })
    ;

  }

  incrementQuantity()
  {
    this.quantity++;
  }
  decrementQuantity()
  {
    this.quantity--;
  }
  updateBasket()
  {
    if(this.product)
    {
      if(this.quantity > this.quantityInBasket)
      {
        const itemToAdd = this.quantity - this.quantityInBasket
        this.quantityInBasket += itemToAdd
        this.basketService.addItemToBasket(this.product, itemToAdd)

      }else{
        const itemsToRemove = this.quantityInBasket - this.quantity;
        this.quantityInBasket -= itemsToRemove;
        this.basketService.removeItemFromBasket(this.product.productId, itemsToRemove)
      }
    }
  }
  //calculate info of comething in component
  get buttenText()
  {
    return this.quantityInBasket === 0? 'Add' : 'update';
  }
}
