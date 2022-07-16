import { ComponentFixture, TestBed } from '@angular/core/testing';

import { RequestbyusersComponent } from './requestbyusers.component';

describe('RequestbyusersComponent', () => {
  let component: RequestbyusersComponent;
  let fixture: ComponentFixture<RequestbyusersComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ RequestbyusersComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(RequestbyusersComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
