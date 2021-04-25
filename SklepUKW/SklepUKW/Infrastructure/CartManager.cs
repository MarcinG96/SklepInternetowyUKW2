using SklepUKW.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SklepUKW.Infrastructure
{
    public class CartManager
    {
        FilmsContext db;
        ISessionManager session;

        public CartManager(FilmsContext db, ISessionManager session)
        {
            this.db = db;
            this.session = session;
        }

        public List<CartItem> GetItems()
        {
            List<CartItem> items;

            if(session.Get<List<CartItem>>(Consts.CartSessionKey) == null)
            {
                items = new List<CartItem>();
            }
            else
            {
                items = session.Get<List<CartItem>>(Consts.CartSessionKey);
            }

            return items;
        }

        public void AddToCart(int filmId)
        {
            var cart = GetItems();
            var thisFilm = cart.Find(f => f.Film.FilmId == filmId);

            if(thisFilm != null)
            {
                thisFilm.Quantity++;
            }
            else
            {
                var newCartItem = db.Films.Where(f => f.FilmId == filmId).SingleOrDefault();

                if(newCartItem != null)
                {
                    var cartItem = new CartItem
                    {
                        Film = newCartItem,
                        Quantity = 1,
                        Value = newCartItem.Price
                    };

                    cart.Add(cartItem);
                }

                session.Set(Consts.CartSessionKey, cart);
            }
        }

        public int RemoveFromCart(int filmId)
        {
            var cart = GetItems();
            var thisFilm = cart.Find(f => f.Film.FilmId == filmId);

            if(thisFilm != null)
            {
                if(thisFilm.Quantity > 1)
                {
                    thisFilm.Quantity--;
                    return thisFilm.Quantity;
                }
                else
                {
                    cart.Remove(thisFilm);
                }
            }

            return 0;
        }

        public decimal GetCartValue()
        {
            var cart = GetItems();
            return cart.Sum(i => (i.Quantity * i.Value));
        }

        public int GetCartQuantity()
        {
            var cart = GetItems();
            return cart.Sum(i => i.Quantity);
        }
    }
}