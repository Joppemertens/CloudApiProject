import { Component, OnInit } from '@angular/core';
import { DeLijnService, IVertrekResult,IHalte,ILijnen} from '../services/delijn.service';
import { resetFakeAsyncZone } from '@angular/core/testing';

@Component({
  selector: 'app-delijn',
  templateUrl: './delijn.component.html',
  styleUrls: ['./delijn.component.scss']
})
export class DelijnComponent implements OnInit {
  
  private _search:string='Bredabaan';
  

  halteResult:IHalte;
  vertrekken:IVertrekResult;
  vertrekResultVanuitSearch:IVertrekResult;
  private _id :number;
 
  constructor(private _svc :DeLijnService) { }

  ngOnInit() {
    this._svc.getVertrekkenHalte(this._search).subscribe(result =>this.halteResult =result);
   // let vertrekResultVanuitSearch : IVertrekResult = this.halteResult.haltes[4];
   
    //console.log(1+1);
    //console.log(this._id);
    //console.log(this.halteResult.haltes[4]);
   // let _id : number = this.vertrekResultVanuitSearch.id;
    
   // this._svc.getVertrekResult(this._id).subscribe(result =>this.vertrekken =result);
  }
  
   // private vertrekResultVanuitSearch : IVertrekResult = this.haltes.haltes[3];
   // private _id : number = this.vertrekResultVanuitSearch.id;
  
  public searchLijnen(value:number){

    console.log(value);

    this._svc.getVertrekResult(value).subscribe(result =>{
      this.vertrekken =result;
      console.log(result);
    });
    console.log();
  }

  get Search(){
    
    return this._search
  }
  set Search(value: string) {
    this._search = value;
    console.log(value);
    this._svc.getVertrekkenHalte(this._search).subscribe(result => this.halteResult = result);
    console.log(this.halteResult);
    
  }
  get Id(){
    return this._id;
  
  }
  set Id(val:number){
    this._id = val;
    
    this._svc.getVertrekResult(this._id).subscribe(result=>this.vertrekken = result);
    
   
  }
  
  


  }
  
  
  
