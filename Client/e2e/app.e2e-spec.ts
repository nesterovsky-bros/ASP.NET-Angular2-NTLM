import { CreditRatings_ClientPage } from './app.po';

describe('credit-ratings.client App', () => {
  let page: CreditRatings_ClientPage;

  beforeEach(() => {
    page = new CreditRatings_ClientPage();
  });

  it('should display message saying app works', () => {
    page.navigateTo();
    expect(page.getParagraphText()).toEqual('app works!');
  });
});
