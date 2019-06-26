import { Airplane } from './../../models/airplane';
import { ApiService } from './../api.service';
import { Component, OnInit } from '@angular/core';
import { Router, ActivatedRoute } from '@angular/router';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';

@Component({
  selector: 'app-airplane-edit',
  templateUrl: './airplane-edit.component.html',
  styleUrls: ['./airplane-edit.component.scss']
})
export class AirplaneEditComponent implements OnInit {

  id: number;
  code: number;
  numberPassengers: number;
  model: string;

  isLoadingResults = false;
  airplaneForm: FormGroup;

  constructor(private router: Router, private route: ActivatedRoute, private api: ApiService, private formBuilder: FormBuilder) { }

  ngOnInit() {

    this.getAirplane(this.route.snapshot.params.id);
    this.airplaneForm = this.formBuilder.group({
      code : [null, Validators.required],
      numberPassengers : [null, Validators.required],
      model : [null, Validators.required]
    });
  }

  getAirplane(id: number) {
    this.api.getAirplane(id).subscribe(data => {
      this.id = data.id;
      this.airplaneForm.setValue({
        code: data.code,
        numberPassengers: data.numberPassengers,
        model: data.model
      });
    });
  }

  upateAirplane(airplane: Airplane) {
    airplane.id = this.route.snapshot.params.id;
    this.isLoadingResults = true;
    this.api.updateAirplane(airplane)
      .subscribe(res => {
          this.isLoadingResults = false;
          this.router.navigate(['/airplane-detail/' + this.id]);
        }, (err) => {
          console.log(err);
          this.isLoadingResults = false;
        }
      );
  }

}
