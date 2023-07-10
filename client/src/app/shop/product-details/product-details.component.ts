import { Component, OnInit } from '@angular/core';
import { IProduct } from 'src/app/shared/models/IProduct';
import { ShopService } from '../shop.service';
import { ActivatedRoute } from '@angular/router';

@Component({
  selector: 'app-product-details',
  templateUrl: './product-details.component.html',
  styleUrls: ['./product-details.component.scss']
})
export class ProductDetailsComponent implements OnInit {
  
  product?: IProduct;
  constructor(private shopService: ShopService, private activatedRoot: ActivatedRoute){}
  
  ngOnInit(): void {
    this.loadProduct();
  }

  loadProduct()
  {
    const id =  this.activatedRoot.snapshot.paramMap.get('id')//+ for subscrivbe
    
    if(id)  this.shopService.getProduct(+id).subscribe({
      next: prod => this.product = prod,
      error: err => console.log(err)
    })
    ;

  }
}
