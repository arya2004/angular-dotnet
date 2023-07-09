import { Component, ElementRef, OnInit, ViewChild } from '@angular/core';
import { IProduct } from '../shared/models/IProduct';
import { ShopService } from './shop.service';
import { IBrand } from '../shared/models/IBrand';
import { IType } from '../shared/models/IType';
import { ShopParams } from '../shared/models/ShopParam';

@Component({
  selector: 'app-shop',
  templateUrl: './shop.component.html',
  styleUrls: ['./shop.component.scss']
})
export class ShopComponent implements OnInit {
  @ViewChild('search') searchTerm?: ElementRef  ;
  produts : IProduct[] = [];
  brands: IBrand[] = [];
  types: IType[] = [];
  shopParams = new ShopParams
  sortOptions = [
    {name: 'Alphabetical', value: 'name'},
    {name: 'Price Low to High', value: 'priceAsc'},
    {name: 'Price High to Low', value: 'pricceDesc'},
  ]
  totalCount = 0;
  constructor(private shopService: ShopService){}

  ngOnInit(): void {
    this.getProducts();
    this.getBrands();
   
    this.getTypes();
  }

  getProducts()
  {
    this.shopService.getProducts(this.shopParams).subscribe({
      next: res => {this.produts = res.data;
        this.shopParams.pageNumber = res.pageIndex;
        this.shopParams.pageSize = res.pageSize;
        this.totalCount = res.totalCount
        console.log(this.totalCount)
      },
      error: err => console.log(err)
    })
  }
  getTypes()
  {
    this.shopService.getTypes().subscribe({
      next: res => this.types = [{productTypeId: 0, name: 'All'}, ...res],
      error: err => console.log(err)
    })
  }
  getBrands()
  {
    this.shopService.getBrands().subscribe({
      //appends 'all' brand to array of res received
      next: res => this.brands = [{productBrandId: 0, name: 'All'}, ...res],
      error: err => console.log(err)
    })
  }

  onBrandSelected(brandId : number)
  {
    this.shopParams.brandId = brandId;
    this.shopParams.pageNumber = 1;
    this.getProducts();
  }
  onTypeSelected(typeId: number)
  {
    this.shopParams.typeId = typeId;
    this.shopParams.pageNumber = 1;
    this.getProducts();
  }

  onSortSelected(event: any)
  {
    this.shopParams.sort = event.target.value;
    this.getProducts();
  }
  onPagedChanged(event:any)
  {
    if(this.shopParams.pageNumber !== event)
    {
      this.shopParams.pageNumber = event;
      this.getProducts();
    }
  }
  onSearch()
  {
    this.shopParams.search = this.searchTerm?.nativeElement.value;
    this.shopParams.pageNumber = 1;
    this.getProducts();
  }

  onReset()
  {
    if(this.searchTerm) this.searchTerm.nativeElement.value = '';
    this.shopParams = new ShopParams();
    this.getProducts();

  }
}
