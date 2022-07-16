import { ComponentFixture, TestBed } from '@angular/core/testing';

import { AddservicereporrtComponent } from './addservicereporrt.component';

describe('AddservicereporrtComponent', () => {
  let component: AddservicereporrtComponent;
  let fixture: ComponentFixture<AddservicereporrtComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ AddservicereporrtComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(AddservicereporrtComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
