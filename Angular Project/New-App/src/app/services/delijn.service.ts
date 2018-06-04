import {Injectable} from '@angular/core';
import {HttpClient} from '@angular/common/http';
import {Observable} from 'rxjs/Observable';

@Injectable()
export class DeLijnService{
    constructor(private _http :HttpClient){}
   
   
    getVertrekkenHalte(location:string):Observable<IHalte>{
        return this._http.get<IHalte>(`https://www.delijn.be/rise-api-search/search/haltes/${location}/1`)
        
    }
    

    getVertrekResult(id:number):Observable<IVertrekResult>{
        return this._http.get<IVertrekResult>(`https://www.delijn.be/rise-api-core/haltes/titel/${id}`)
        
    }

}

export interface IHalte{
    belevingen:any;
    belevingenCount:number;
    gemeenten:any;
    gemmeentenCount:number;
    haltes:IVertrekResult[];
}
export interface IVertrekResult{
    afstand: number;
    bestemmingen?: any;
    coordinaat?: any;
    entiteitNummer: number;
    halteNummer: number;
    halteUrl: string;
    huidigeDag: string;
    huidigeTijd: string;
    id: number;
    interneLijnnummers?: any;
    laatstGebruikt?: any;
    lijnen: ILijnen[];
    name?: any;
    omleidingen?: any;
    omschrijvingGemeente?: any;
    omschrijvingHighlighted?: any;
    omschrijvingKort?: any;
    omschrijvingLang?: any;
    publiek: boolean;
    storingen: any[];
    syncStatus?: any;
    toegankelijkheidsStatus: any[];
}
export interface ILijnen {
    bestemming: string;
    entiteitNummer: number;
    gemeentes?: any;
    haltes?: any;
    id: number;
    internLijnnummer: string;
    kleurAchterGrond: string;
    kleurAchterGrondRand: string;
    kleurVoorGrond: string;
    kleurVoorGrondRand: string;
    lijnGeldigVan?: any;
    lijnNummer: number;
    lijnNummerPubliek: string;
    lijnRichting: string;
    lijnType: string;
    lijnTypeLink: string;
    lijnUrl: string;
    omschrijving: string;
    omschrijvingHighlighted?: any;
    richtingCode: number;
    richtingCodeAndereRichting: number;
    ritNummer: number;
    ritOrder: number;
    vertrekCalendar: any;
    vertrekTijd: string;
    viaBestemming: string;
}

