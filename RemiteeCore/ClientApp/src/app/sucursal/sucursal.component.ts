import { Component, Inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Router, ActivatedRoute, Params } from '@angular/router';
import { PayerBranch } from './PayerBranch';

@Component({
  selector: 'app-sucursal',
  templateUrl: './sucursal.component.html'
})
export class SucursalComponent {
  private _http: HttpClient;
  private _baseUrl: string;

  public redes: Payer[];
  public sucursal: PayerBranch;

  constructor(
    private route: ActivatedRoute,
    private router: Router,
    http: HttpClient,
    @Inject('BASE_URL') baseUrl: string
  ) {
    this._http = http;
    this._baseUrl = baseUrl;

    this.sucursal = new PayerBranch();
    this.route.params.forEach((params: Params) => {
      this.sucursal.id = params["id"];

      if (this.sucursal.id != null) {
        this._http.get<PayerBranch>(this._baseUrl + 'api/SampleData/PayerBranchGetOne?id=' + this.sucursal.id).subscribe(result => {
          this.sucursal = result;
          console.log(result);
        }, error => console.error(error));
      }
    });

    http.get<Payer[]>(baseUrl + 'api/SampleData/Payer').subscribe(result => {
      this.redes = result;
    }, error => console.error(error));

  }

  onSubmit() {
    if (this.sucursal.id != null) {
      console.log("es distinto de null, put");
      this._http.put<PayerBranch>(this._baseUrl + 'api/SampleData/PayerBranch', this.sucursal).subscribe(result => {
        this.router.navigate(['/sucursales']);
      }, error => console.error(error));
    }
    else {
      this._http.post<PayerBranch>(this._baseUrl + 'api/SampleData/PayerBranch', this.sucursal).subscribe(result => {
        this.router.navigate(['/sucursales']);
      }, error => console.error(error));
    }

    
  }

  cancelar() {
    this.router.navigate(['/sucursales']);
  }
}

interface Payer {
  Id: number;
  Code: string;
  Name: string;
}
