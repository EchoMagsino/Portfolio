// JM Portfolio — navigation, scroll spy and reveal-on-scroll.

document.addEventListener('DOMContentLoaded', () => {
    const header = document.getElementById('siteHeader');
    const toggle = document.getElementById('navToggle');
    const links = document.getElementById('navLinks');
    const navAnchors = links ? Array.from(links.querySelectorAll('a')) : [];

    // Header gets a border/shadow once the page scrolls.
    const onScroll = () => {
        header?.classList.toggle('is-scrolled', window.scrollY > 8);
    };
    onScroll();
    window.addEventListener('scroll', onScroll, { passive: true });

    // Mobile menu.
    const closeMenu = () => {
        if (!links || !toggle) return;
        links.classList.remove('is-open');
        toggle.setAttribute('aria-expanded', 'false');
    };

    toggle?.addEventListener('click', () => {
        const open = links?.classList.toggle('is-open') ?? false;
        toggle.setAttribute('aria-expanded', String(open));
    });

    navAnchors.forEach((anchor) => anchor.addEventListener('click', closeMenu));

    document.addEventListener('click', (event) => {
        if (!links || !toggle) return;
        if (!links.contains(event.target) && !toggle.contains(event.target)) closeMenu();
    });

    document.addEventListener('keydown', (event) => {
        if (event.key === 'Escape') closeMenu();
    });

    // Highlight the section currently in view.
    const sections = navAnchors
        .map((anchor) => document.querySelector(anchor.getAttribute('href')))
        .filter(Boolean);

    const setActive = (id) => {
        navAnchors.forEach((anchor) => {
            anchor.classList.toggle('is-active', anchor.getAttribute('href') === `#${id}`);
        });
    };

    if ('IntersectionObserver' in window && sections.length) {
        const spy = new IntersectionObserver((entries) => {
            entries
                .filter((entry) => entry.isIntersecting)
                .sort((a, b) => b.intersectionRatio - a.intersectionRatio)
                .slice(0, 1)
                .forEach((entry) => setActive(entry.target.id));
        }, { rootMargin: '-45% 0px -45% 0px', threshold: [0, 0.25, 0.5, 1] });

        sections.forEach((section) => spy.observe(section));
    }

    // Reveal blocks as they enter the viewport.
    const revealItems = document.querySelectorAll('.reveal');

    if (!('IntersectionObserver' in window)) {
        revealItems.forEach((item) => item.classList.add('is-visible'));
        return;
    }

    const revealer = new IntersectionObserver((entries, observer) => {
        entries.forEach((entry) => {
            if (!entry.isIntersecting) return;
            const delay = entry.target.dataset.delay;
            if (delay) entry.target.style.setProperty('--delay', `${delay}ms`);
            entry.target.classList.add('is-visible');
            observer.unobserve(entry.target);
        });
    }, { rootMargin: '0px 0px -8% 0px', threshold: 0.12 });

    revealItems.forEach((item) => revealer.observe(item));
});
