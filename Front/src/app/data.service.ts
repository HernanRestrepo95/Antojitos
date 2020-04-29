import { Injectable } from '@angular/core';
import { Http, Response, Headers, RequestOptionsArgs, RequestOptions } from '@angular/http';

import { Observable } from 'rxjs/Observable';

import { Client } from './shared/client.model';

import 'rxjs/add/observable/throw';
import 'rxjs/add/operator/catch';
import 'rxjs/add/operator/map';

@Injectable()
export class DataService {

  client: Client;

  constructor(private http: Http) { }

  public setSession(_client){
    this.client = _client;
  }

  public getSession(){
      return this.client;
  }

  setInvoice(invoice): Observable<any> {
    let customHeaders = new Headers({
      'Content-type': 'application/json'
    });

    const requestOptions: RequestOptionsArgs = { headers: customHeaders };
    const body=JSON.stringify(invoice);
    
    return this.http.post("/api/TEST_FACTURA", body,requestOptions)
    .map(this.extractData)
    .catch(this.handleError);
  }

  getProducts(): Observable<any> {
    return this.http.get("/api/TEST_PRODUCTO")
                    .map(this.extractData)
                    .catch(this.handleError);
  }

  getClientById(id): Observable<any> {
      return this.http.get("/api/TEST_CLIENTE/"+id)
                      .map(this.extractData)
                      .catch(this.handleError);
  }

  private extractData(res: Response) {
    const body = res.json();
    return body || { };
  }

  private handleError (error: any) {
    // In a real world app, we might use a remote logging infrastructure
    // We'd also dig deeper into the error to get a better message
    const errMsg = (error.message) ? error.message :
      error.status ? `${error.status} - ${error.statusText}` : 'Server error';
    console.error(errMsg); // log to console instead
    return Observable.throw(errMsg);
  }

}
