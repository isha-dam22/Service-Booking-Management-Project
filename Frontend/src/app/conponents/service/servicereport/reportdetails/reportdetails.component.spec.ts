import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ReportdetailsComponent } from './reportdetails.component';

describe('ReportdetailsComponent', () => {
  let component: ReportdetailsComponent;
  let fixture: ComponentFixture<ReportdetailsComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ ReportdetailsComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(ReportdetailsComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
