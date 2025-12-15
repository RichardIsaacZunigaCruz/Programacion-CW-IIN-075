
        // POST: Cuentas/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,numero,descripcion,creditos,debitos,balance")] Cuenta cuenta)
        {
            if (ModelState.IsValid)
            {
                cuenta.balance = cuenta.creditos - cuenta.debitos;
                _context.Add(cuenta);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(cuenta);
        }
