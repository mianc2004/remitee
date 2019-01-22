import { Component, Inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Router, ActivatedRoute, Params } from '@angular/router';

@Component({
  selector: 'app-sucursales',
  templateUrl: './sucursales.component.html'
})
export class SucursalesComponent {
  public list: PayerBranch[];
  private _http: HttpClient;
  private _baseUrl: string;

  constructor(
    private route: ActivatedRoute,
    private router: Router,
    http: HttpClient,
    @Inject('BASE_URL') baseUrl: string
  ) {
    this._http = http;
    this._baseUrl = baseUrl;

    http.get<PayerBranch[]>(baseUrl + 'api/SampleData/PayerBranch').subscribe(result => {
      this.list = result;
    }, error => console.error(error));
  }

  eliminar(id: number) {
    var pos = -1;
    for (var i = 0; i < this.list.length; i++) {
      if (this.list[i].id == id) {
        pos = i;
      }
    }
    this._http.delete(this._baseUrl + 'api/SampleData/PayerBranch?id=' + id).subscribe(result => {

      this.list.splice(pos, 1);
    }, error => console.error(error));
  }

  modificar(id: number) {
    this.router.navigate(['/sucursal', id.toString()]);
  }

  nueva() {
    this.router.navigate(['/sucursal']);
  }
}

interface PayerBranch {
  id: number;
  code: string;
  name: string;
  formattedAddress: string;
  payer: string;
}
